using System;

namespace GymReservationSystem.DomainModel
{
    public class Client : Entity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Gender { get; set; }

        
        public DateTime BirthDate { get; set; }

        public int PhoneNumber { get; set; }
       
        public DateTime RegistrationDate { get; set; }
    } 
}