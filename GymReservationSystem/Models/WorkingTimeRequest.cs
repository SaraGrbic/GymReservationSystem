using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GymReservationSystem.Models
{
    public class WorkingTimeRequest
    {
        public int Id { get; set; }

        public TimeSpan StartTime { get; set; }

        public TimeSpan EndTime { get; set; }

        public DayOfWeek DayOfWeek { get; set; }

      

   



    }
}