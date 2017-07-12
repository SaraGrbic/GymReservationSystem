using System;

namespace GymReservationSystem.DomainModel
{
    public class Holiday : Entity
    {
        public DateTime Day { get; set; }

        public string Title { get; set; }
    }
}
