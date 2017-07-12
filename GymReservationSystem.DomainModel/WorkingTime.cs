
using System;

namespace GymReservationSystem.DomainModel
{
    public class WorkingTime : Entity
    {
        public TimeSpan StartTime { get; set; }

        public TimeSpan EndTime { get; set; }

        public DayOfWeek DayOfWeek { get; set; }
    }
}
