using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GymReservationSystem.Models
{
    public class HolidayRequest
    {
        public int Id { get; set; }
        public DateTime Day { get; set; }

        public string Title { get; set; }
    }
}