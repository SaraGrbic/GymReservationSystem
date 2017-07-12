using System;


namespace GymReservationSystem.Models
{
    public class ClosedTimeRequest
    {
        public int Id { get; set; }
        public TimeSpan StartTime { get; set; }

        public TimeSpan EndTime { get; set; }

        public DayOfWeek DayOfWeek { get; set; }

        public string Reason { get; set; }
    }
}