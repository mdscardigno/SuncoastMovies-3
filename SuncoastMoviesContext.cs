using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace SuncoastMovies
{
    public class SuncoastMoviesContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }// a property of our database context
        public DbSet<Rating> Ratings { get; set; }// a property of our database context
        public DbSet<Role> Roles { get; set; }// a property of our database context
        public DbSet<Actor> Actors { get; set; }// a property of our database context

        //boilerplate code
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("server=localhost;database=SuncoastMovies");

            //This will tell Entity Framework to log all the SQL it is generating to the console
            var loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
            optionsBuilder.UseLoggerFactory(loggerFactory);
        }
    }
}