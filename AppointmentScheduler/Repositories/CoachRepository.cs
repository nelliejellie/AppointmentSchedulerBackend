using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CsvHelper;
using System.IO;
using System.Globalization;
using AppointmentScheduler.Models;
using CsvHelper.Configuration;
using System.Text;

namespace AppointmentScheduler.Repositories
{
    public static class CoachRepository
    {
        public static List<CoachSchedule> GetCoaches()
        {
         
            var fileName = @"coaches.csv";
            var configuration = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Encoding = Encoding.UTF8, // Our file uses UTF-8 encoding.
                Delimiter = "," // The delimiter is a comma.
            };
            using (var fs = File.Open(fileName, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                using (var textReader = new StreamReader(fs, Encoding.UTF8))
                using (var csv = new CsvReader(textReader, configuration))
                {
                    var data = csv.GetRecords<CoachSchedule>().ToList();
                    return data;
                }
            }
            
        }

        public static List<CoachSchedule> GetCoachByName(string name)
        {
            var coach = GetCoaches().Where(c => c.Name == name).ToList();

            return coach;
        }

        public static List<string> GetCoachTime(string name, string day)
        {
            if(name == "Christy Schumm" && day == "Monday")
            {
                return new List<string> { "9:00AM", "10:00AM", "11:00AM", "12:00AM", "1:00PM", "2:00PM", "3:00PM", "4:00PM", "5:00PM", "5:30PM" };
            }else if(name == "Christy Schumm" && day == "Tuesday")
            {
                return new List<string> { "8:00AM","9:00Am", "10:00AM", "11:00AM", "12:00AM", "1:00PM", "2:00PM", "3:00PM", "4:00PM" };
            }
            else if (name == "Christy Schumm" && day == "Thursday")
            {
                return new List<string> { "9:00Am", "10:00AM", "11:00AM", "12:00AM", "1:00PM", "2:00PM", "3:00PM", "4:00PM" };
            }
            else if (name == "Christy Schumm" && day == "Friday")
            {
                return new List<string> {"7:00PM", "8:00AM", "9:00Am", "10:00AM", "11:00AM", "12:00AM", "1:00PM", "2:00PM" };
            }
            else if (name == "Natalia Stanton Jr." && day == "Tuesday")
            {
                return new List<string> { "8:00AM", "9:00Am", "10:00AM" };
            }
            else if (name == "Natalia Stanton Jr." && day == "Wednesday")
            {
                return new List<string> { "11:00AM", "12:00AM", "1:00PM", "2:00PM","3:00PM", "4:00PM","5:00PM","6:00"};
            }
            else if (name == "Natalia Stanton Jr." && day == "Saturday")
            {
                return new List<string> { "9:00Am", "10:00AM", "11:00AM", "12:00AM", "1:00PM", "2:00PM", "3:00PM" };
            }
            else if (name == "Natalia Stanton Jr." && day == "Sunday")
            {
                return new List<string> { "8:00AM", "9:00Am", "10:00AM", "11:00AM", "12:00AM", "1:00PM", "2:00PM", "3:00PM" };
            }
            else if (name == "Nola Murazik V" && day == "Monday")
            {
                return new List<string> { "8:00AM", "9:00Am", "10:00AM", "11:00AM" };
            }
            else if (name == "Nola Murazik V" && day == "Tuesday")
            {
                return new List<string> { "11:00AM", "12:00AM", "1:00PM"};
            }
            else if (name == "Nola Murazik V" && day == "Wednesday")
            {
                return new List<string> { "8:00AM", "9:00Am", "10:00AM" };
            }
            else if (name == "Nola Murazik V" && day == "Saturday")
            {
                return new List<string> { "8:00AM", "9:00Am", "10:00AM", "11:00AM" };
            }
            else if (name == "Nola Murazik V" && day == "Sunday")
            {
                return new List<string> { "7:00AM","8:00AM", "9:00Am" };
            }
            else if (name == "Elyssa O'Kon" && day == "Monday")
            {
                return new List<string> { "9:00Am", "10:00AM", "11:00AM", "12:00AM", "1:00PM", "2:00PM", "3:00PM" };
            }
            else if (name == "Elyssa O'Kon" && day == "Tuesday")
            {
                return new List<string> { "6:00AM","7:00PM", "8:00AM", "9:00Am", "10:00AM", "11:00AM", "12:00AM", "1:00PM" };
            }
            else if (name == "Elyssa O'Kon" && day == "Wednesday")
            {
                return new List<string> { "6:00AM", "7:00PM", "8:00AM", "9:00Am", "10:00AM", "11:00AM" };
            }
            else if (name == "Elyssa O'Kon" && day == "Friday")
            {
                return new List<string> { "8:00AM", "9:00Am", "10:00AM", "11:00AM", "12:00AM" };
            }
            else if (name == "Elyssa O'Kon" && day == "Saturday")
            {
                return new List<string> { "9:00Am", "10:00AM", "11:00AM", "12:00AM", "1:00PM", "2:00PM", "3:00PM","4:00PM" };
            }
            else if (name == "Elyssa O'Kon" && day == "Sunday")
            {
                return new List<string> { "8:00AM", "9:00Am", "10:00AM" };
            }
            else if (name == "Dr. Geovany Keebler" && day == "Sunday")
            {
                return new List<string> { "8:00AM", "9:00Am", "10:00AM" };
            }
            else if (name == "Dr. Geovany Keebler" && day == "Sunday")
            {
                return new List<string> { "8:00AM", "9:00Am", "10:00AM" };
            }
            return new List<string> { "No Available Schedules" };
        }
        
    }
}
