using AppointmentScheduler.DataAccess;
using AppointmentScheduler.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentScheduler.Repositories
{
    public class AppointmentRepository
    {
        private readonly AppDbContext _db;

        public AppointmentRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task<List<Appointments>> AllAppointments()
        {
            return await _db.MyProperty.ToListAsync();
        }

        public async Task<bool> CreateAppointment(Appointments appointments)
        {
            var appointment = await _db.MyProperty.AddAsync(appointments);

            var changes = await _db.SaveChangesAsync();

            return changes > 0;
        }

        
    }
}
