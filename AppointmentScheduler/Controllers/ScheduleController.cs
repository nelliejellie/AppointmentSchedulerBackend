using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppointmentScheduler.Models;
using AppointmentScheduler.Repositories;
using AppointmentScheduler.Entities;
using AppointmentScheduler.DTOs;
using Microsoft.AspNetCore.Cors;

namespace AppointmentScheduler.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class ScheduleController : ControllerBase
    {
        private readonly UserRepository _userRepository;

        public ScheduleController(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        // get all coaches
        [HttpGet]
        [Route("GetCoaches")]
        public IEnumerable<CoachSchedule> GetCoachesSchedule()
        {
            return CoachRepository.GetCoaches();
        }

        // get a particular coache schedule
        [HttpPost]
        [Route("coachSchedule")]
        public List<CoachSchedule> GetCoachSchedule([FromForm]string name)
        {
            return CoachRepository.GetCoachByName(name);
        }

        //get time of coach
        [HttpPost]
        [Route("time")]
        public IActionResult GetTime([FromForm] string name, [FromForm] string day)
        {

            var checkDay = CoachRepository.GetCoachByName(name);
            var isDayValid = checkDay.Any(check => check.WeekDay == day);

            if(isDayValid)
                return Ok(CoachRepository.GetCoachTime(name,day));

            return BadRequest(new Response { Success = false, message = $"The doctor has no schedule on {day}" });

        }

        [HttpGet]
        [Route("AllUsers")]
        public async Task<IActionResult> GetUsers()
        {
            var allUsers = await _userRepository.AllUsers();
            return Ok(allUsers);
        }

        [HttpPost]
        [Route("AddUsers")]
        public async Task<IActionResult> CreateUser([FromForm]string name)
        {
            try
            {
                var allUsers = await _userRepository.AllUsers();
                var checkUserAlreadyExists = allUsers.Any(user => user.Name == name);
                if (checkUserAlreadyExists)
                {
                    var user = await _userRepository.GetUserByName(name);
                    return Ok(new Response { Success = true, message = "User was logged in successfully" });
                }
                var newUser = new User
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = name
                };
                await _userRepository.AddUser(newUser);
                return Ok(new Response { Success = true, message = "User was created successfully" });

            }
            catch (Exception ex)
            {

                return BadRequest(new Response { Success = false, message = ex.Message });
            }
            
        }
    }

    // returns data for a particular doctor
}
