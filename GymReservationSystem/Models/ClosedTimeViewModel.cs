using System;


namespace GymReservationSystem.Models
{
    public class ClosedTimeViewModel
    {
        public int Id { get; set; }
        public string StartTime { get; set; }

        public string EndTime { get; set; }

        public string DayOfWeek { get; set; }

        public string Reason { get; set; }
    }
}