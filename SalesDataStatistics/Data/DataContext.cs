using Microsoft.EntityFrameworkCore;
using SalesDataStatistics.Entities;

namespace SalesDataStatistics.Data
{
    public class DataContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public DataContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public DbSet<Transaction> Transactions { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Transaction>().ToTable("Transactions");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (_configuration is not null)
            {
                optionsBuilder.UseSqlServer(_configuration.GetConnectionString("WebConnection"));
            }
        }


    }
}
