using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentScheduler.Entities
{
    public class Appointments
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string Day { get; set; }
        public string Time { get; set; }
        public string DoctorsName { get; set; }
        public bool IsBookedOnDayAndTime { get; set; }
    }
}
