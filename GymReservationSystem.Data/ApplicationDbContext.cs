using GymReservationSystem.DomainModel;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace GymReservationSystem.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Holiday> Holidays { get; set; }

        public DbSet<ClosedTime> ClosedTimes { get; set; }

        public DbSet<WorkingTime> WorkingTimes { get; set; }

        public DbSet<Client> Clients { get; set; }

        public ApplicationDbContext()
            : base("GymReservationSystem", throwIfV1Schema: false)
        {
            //Database.SetInitializer(new ApplicationDbInitializer());
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
 
    }
}