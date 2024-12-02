using Luftkvalitet;
using Microsoft.EntityFrameworkCore;

namespace AirQualityREST.Luftkvalitet
{
    public class MeasurmentDbContext : DbContext
    {

        public DbSet<Measurement> Measurements { get; set; }

       


        public MeasurmentDbContext(DbContextOptions<MeasurmentDbContext> options) : base(options)
        {
            
        }

    }
}
