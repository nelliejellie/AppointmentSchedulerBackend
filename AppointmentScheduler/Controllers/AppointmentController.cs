using AppointmentScheduler.DTOs;
using AppointmentScheduler.Entities;
using AppointmentScheduler.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentScheduler.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly AppointmentRepository _appointmentRepository;
        private readonly UserRepository _userRepository;

        public AppointmentController(AppointmentRepository appointmentRepository, UserRepository userRepository)
        {
            _appointmentRepository = appointmentRepository;
            _userRepository = userRepository;
        }

        [HttpGet]
        [Route("AllAppointments")]
        public async Task<IActionResult> Appointments()
        {
            var appointments = await _appointmentRepository.AllAppointments();

            return Ok(appointments);
        }

        [HttpPost]
        [Route("AddAppointment")]
        public async Task<IActionResult> CreateAppointment([FromForm]AppointmentRequestDto appointmentRequestDto, [FromForm]string name)
        {
            var user = await _userRepository.GetUserByName(name);
            var appointments = await _appointmentRepository.AllAppointments();
            var alreadyBooked = appointments.Where(appointment => appointment.Day == appointmentRequestDto.Day && appointment.Time == appointmentRequestDto.Time && appointment.DoctorsName == appointmentRequestDto.DoctorsName).ToList();
            if (alreadyBooked.Count == 0)
            {
                var newAppointment = new Appointments
                {
                    Id = Guid.NewGuid().ToString(),
                    Day = appointmentRequestDto.Day,
                    UserId = user.Name,
                    DoctorsName = appointmentRequestDto.DoctorsName,
                    Time = appointmentRequestDto.Time,
                    IsBookedOnDayAndTime = true
                };
                var create = _appointmentRepository.CreateAppointment(newAppointment);
                return Ok(new Response { Success=true, message=$"Your appointment for {appointmentRequestDto.Time} on {appointmentRequestDto.Day} has been booked with {appointmentRequestDto.DoctorsName}"});
            }

            return BadRequest(new Response { Success = false, message = $"{appointmentRequestDto.DoctorsName} already has an appointment at {appointmentRequestDto.Time}" });
            
        }
    }
}
