using Microsoft.EntityFrameworkCore;
namespace SuncoastMovies
{
    public class SuncoastMoviesContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }// a property of our database context



        //boilerplate code
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("server=localhost;database=SuncoastMovies");
        }
    }
}