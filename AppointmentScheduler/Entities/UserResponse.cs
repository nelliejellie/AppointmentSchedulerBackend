using AppointmentScheduler.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentScheduler.DTOs
{
    public class UserResponse
    {
        public bool Success { get; set; }
        public string message { get; set; }
    }
}
