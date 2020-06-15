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

            modelBuilder.Entity<Movie>().HasData(new Movie()
            {
                Id = 1,
                Title = "TestFilm",
                Description = "yu"
            });
        }

        public DbSet<Movie> Movies { get; set; }

    }
}
