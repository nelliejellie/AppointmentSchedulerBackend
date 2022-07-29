using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CsvHelper.Configuration;
using CsvHelper.Configuration.Attributes;

namespace AppointmentScheduler.Models
{
    public class CoachSchedule
    {
        [Name("Name")]
        public string Name { get; set; }
        [Name("Day of Week")]
        public string WeekDay { get; set; }
        [Name("Available at")]
        public string AvailableAt { get; set; }
        [Name("Available until")]
        public string AvailableUntill { get; set; }
    }
}
