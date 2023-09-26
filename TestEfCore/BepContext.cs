using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using testEfCore.Models;

namespace testEfCore
{
    public class BepContext : DbContext
    {
        public DbSet<FinData> FinData { get; set; }
        public DbSet<BudgetData> BudgetData { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            IConfiguration configuration = builder.Build();

            // Spécifiez ici votre chaîne de connexion SQL Server
            string connectionString = configuration.GetConnectionString("Database");
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<FinData>().HasKey(f => f.Id);
        }
    }
}





