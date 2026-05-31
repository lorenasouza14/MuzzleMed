using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace MuzzleMedBackend.Infrastructure.Persistence
{
    public class MuzzleMedDbContextFactory : IDesignTimeDbContextFactory<MuzzleMedDbContext>
    {
        public MuzzleMedDbContext CreateDbContext(string[] args)
        {
            
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<MuzzleMedDbContext>();
            var connectionString = configuration.GetConnectionString("DefaultConnection");

           
            var serverVersion = new MySqlServerVersion(new System.Version(8, 0));

            optionsBuilder.UseMySql(connectionString, serverVersion);

            return new MuzzleMedDbContext(optionsBuilder.Options);
        }
    }
}