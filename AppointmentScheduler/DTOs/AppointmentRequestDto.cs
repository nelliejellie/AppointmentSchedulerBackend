using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentScheduler.DTOs
{
    public class AppointmentRequestDto
    {
        public string Day { get; set; }
        public string DoctorsName { get; set; }
        public string Time { get; set; }
    }
}
