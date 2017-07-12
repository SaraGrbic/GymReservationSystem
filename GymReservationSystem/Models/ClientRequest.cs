using System;

namespace GymReservationSystem.Models
{
    public class ClientRequest
    {
        public int Id { get; set; }
      
        public DateTime BirthDate { get; set; }
       
        public DateTime RegistrationDate { get; set; }
        public string FirstName { get;  set; }
        public string LastName { get; set; }
        public string Gender { get;  set; }
        public int PhoneNumber { get;  set; }
    }
}