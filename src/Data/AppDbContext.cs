using Microsoft.EntityFrameworkCore;
using EventLiteWeb.Models;

namespace EventLiteWeb.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Event> Events { get; set; } 

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("Data Source=events.db");
            }
        }
    }
}