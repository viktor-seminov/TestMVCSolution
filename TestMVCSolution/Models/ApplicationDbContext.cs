using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace TestMVCSolution.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Customers> Customers { get; set; }
        public DbSet<Movies> Movies { get; set; }
        public DbSet<MembeshipType> MembershipTypes { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}