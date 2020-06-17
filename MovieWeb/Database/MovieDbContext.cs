using Microsoft.EntityFrameworkCore;
using MovieWeb.Domain;

namespace MovieWeb.Database
{
    public class MovieDbContext : DbContext
    {
        public MovieDbContext(DbContextOptions<MovieDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<WatchStatus>().HasData(
                new WatchStatus()
                {
                    Id = 1,
                    Name = "Nog niet gezien"
                },
                new WatchStatus()
                {
                    Id = 2,
                    Name = "Al gezien"
                },
                new WatchStatus()
                {
                    Id = 3,
                    Name = "Nooit meer zien!!!"
                },
                new WatchStatus()
                {
                    Id = 4,
                    Name = "Nog eens opnieuw zien"
                });
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<WatchStatus> WatchStatuses { get; set; }
    }
}
