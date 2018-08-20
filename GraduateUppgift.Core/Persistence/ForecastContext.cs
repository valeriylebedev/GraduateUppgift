using Microsoft.EntityFrameworkCore;

namespace GraduateUppgift.Core.Persistence
{
    public class ForecastContext : DbContext
    {
        public ForecastContext(DbContextOptions options) : base(options) { }
    }
}
