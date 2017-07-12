using System;

namespace GymReservationSystem.Models
{
    public class WorkingTimeViewModel
    {
        public int Id { get; set; }

        public string StartTime { get; set; }

        public string EndTime { get; set; }

        public string DayOfWeek { get; set; }
    }
}