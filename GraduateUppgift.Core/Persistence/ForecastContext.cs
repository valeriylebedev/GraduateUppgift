using GraduateUppgift.Core.Persistence.Models;
using Microsoft.EntityFrameworkCore;

namespace GraduateUppgift.Core.Persistence
{
    public class ForecastContext : DbContext
    {
        public ForecastContext() : base() { }

        public ForecastContext(DbContextOptions options) : base(options) { }

        public virtual DbSet<Country> Countries { get; set; }

        //public DbSet<City> Cities { get; set; }
    }
}
