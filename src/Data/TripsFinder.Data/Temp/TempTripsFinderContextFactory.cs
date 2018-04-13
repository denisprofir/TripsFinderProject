using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using TripsFinder.Data.Context;

namespace TripsFinder.Data.Temp
{
    public class TempTripsFinderContextFactory : IDesignTimeDbContextFactory<TripsFinderContext>
    {
        public TripsFinderContext CreateDbContext(string[] args)
        {
            var builder = new ConfigurationBuilder();
            
            builder.SetBasePath(Directory.GetCurrentDirectory());

            builder.AddJsonFile("appsettings.json");

            IConfigurationRoot config = builder.Build();

            string connectionString = config.GetConnectionString("TripsFinderConnection");

            var optionsBuilder = new DbContextOptionsBuilder<TripsFinderContext>();
            DbContextOptions<TripsFinderContext> options = optionsBuilder
                .UseSqlServer(connectionString)
                .Options;

            return new TripsFinderContext(options);
        }
    }
}