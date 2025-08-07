using Microsoft.EntityFrameworkCore;
using MovieAPI.Entities;

namespace MovieAPI.AppDbContext
{
    public class MovieDbContext : DbContext
    {
        public MovieDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
