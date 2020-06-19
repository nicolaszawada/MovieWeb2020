using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MovieWeb.Domain;

namespace MovieWeb.Database
{
    public class MovieDbContext : IdentityDbContext<MovieAppUser>
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

            modelBuilder.Entity<MovieTag>()
                .HasKey(mt => new { mt.MovieId, mt.TagId });

            modelBuilder.Entity<MovieTag>()
                .HasOne(mt => mt.Movie)
                .WithMany(m => m.MovieTags)
                .HasForeignKey(mt => mt.MovieId);

            modelBuilder.Entity<MovieTag>()
                .HasOne(mt => mt.Tag)
                .WithMany(t => t.MovieTags)
                .HasForeignKey(mt => mt.TagId);

            modelBuilder.Entity<Tag>()
                .HasData(
                new Tag() { Id = 1, Name = "Verschietend" },
                new Tag() { Id = 2, Name = "Grappig" },
                new Tag() { Id = 3, Name = "Nice" },
                new Tag() { Id = 4, Name = "Demo" });
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<WatchStatus> WatchStatuses { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<MovieTag> MovieTags { get; set; }
    }
}
