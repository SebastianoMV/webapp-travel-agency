using Microsoft.EntityFrameworkCore;
using webapp_travel_agency.Models;

namespace webapp_travel_agency.Data
{
    public class PgContext : DbContext
    {
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
