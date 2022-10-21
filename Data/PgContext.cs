using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using webapp_travel_agency.Models;

namespace webapp_travel_agency.Data
{
    public class PgContext : IdentityDbContext<IdentityUser>
    {

        public PgContext(DbContextOptions<PgContext> options) : base(options)
        {

        }
        public DbSet<Package> Packages { get; set; }

        public PgContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=travel-db;Integrated Security=True");
        }
    }
}
