using System;

namespace GymReservationSystem.DomainModel
{
    public class ClosedTime : Entity
    {
        public TimeSpan StartTime { get; set; }

        public TimeSpan EndTime { get; set; }

        public DayOfWeek DayOfWeek { get; set; }

        public string Reason { get; set; }
    }
}
