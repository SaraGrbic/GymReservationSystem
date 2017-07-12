using Microsoft.AspNet.Identity.EntityFramework;

namespace GymReservationSystem.DomainModel
{
    public class ApplicationRole : IdentityRole
    {
        public ApplicationRole() : base() { }
        public ApplicationRole(string name) : base(name) { }
        public string Description { get; set; }
    }
}
