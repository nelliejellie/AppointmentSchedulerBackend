using AppointmentScheduler.DataAccess;
using AppointmentScheduler.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentScheduler.Repositories
{
    public class UserRepository
    {
        private readonly AppDbContext _db;

        public UserRepository(AppDbContext db)
        {
            _db = db;
        }
        public async Task<List<User>> AllUsers()
        {
            return await _db.Users.ToListAsync();
        }
        public async Task<bool> AddUser(User user)
        {
            var newUser = await _db.Users.AddAsync(user);

            var changes = await _db.SaveChangesAsync();

            return changes > 0;
        }

        public async Task<User> GetUser(string Id)
        {
            var user = await _db.Users.FirstOrDefaultAsync(user => user.Id == Id);
            return user;
        }

        public async Task<User> GetUserByName(string name)
        {
            var user = await _db.Users.FirstOrDefaultAsync(user => user.Name == name);
            return user;
        }
    }
}
