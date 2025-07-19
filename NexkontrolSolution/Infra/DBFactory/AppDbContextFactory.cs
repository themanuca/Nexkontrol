using Infra.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.DBFactory
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var basePath = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), "..", "NexkontrolAPI"));
            var config = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json", optional: false)
                .Build();


            // Get connection string from appsettings.json
#pragma warning disable CS8600 // Conversão de literal nula ou possível valor nulo em tipo não anulável.
            string connectionString = config.GetConnectionString("DefaultConnection");
#pragma warning restore CS8600 // Conversão de literal nula ou possível valor nulo em tipo não anulável.

            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new AppDbContext(optionsBuilder.Options);
        }
    }
    
}
