using Microsoft.EntityFrameworkCore;
using SpaceWeather.Entity;

namespace DataAccess
{
    public class SpaceWeatherContext : DbContext
    {
        public SpaceWeatherContext(DbContextOptions<SpaceWeatherContext> options) : base(options) {}
        public DbSet<Planet> Planets { get; set; }
        public DbSet<Satellite> Satellites { get; set; }
    }
}
