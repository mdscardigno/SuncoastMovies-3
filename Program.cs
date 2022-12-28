using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace SuncoastMovies
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Suncoast Movies");
            // +--------------------------------+           +---------------------------+
            // |            Movies              |           |         Ratings           |
            // |                                |           |                           |
            // |    Id                  SERIAL  |           |     Id           SERIAL   |
            // |    Title               TEXT    | many  one |     Description  TEXT     |
            // |    PrimaryDirector     TEXT    <----------->                           |
            // |    YearReleased        INT     |           +---------------------------+
            // |    Genre               TEXT    |
            // |                                |
            // +-------------^------------------+
            //               | one
            //               |
            //               |
            //               |
            //               |
            //               | many
            //       +-------v----------------+               +-------------------------+
            //       |        Roles           |               |          Actors         |
            //       |                        | many      one |                         |
            //       |   Id            SERIAL |<------------> |    Id          SERIAL   |
            //       |   CharacterName TEXT   |               |    FullName    TEXT     |
            //       |                        |               |    Birthday    DATE     |
            //       |                        |               |                         |
            //       +------------------------+               +-------------------------+


            var context = new SuncoastMoviesContext();

            //this feels like
            //
            // var transactionCount = transactions.Count();
            // var dinoCount = dinos.Count();

            var movieCount = context.Movies.Count();
            Console.WriteLine("There are " + movieCount + " movies in the database");
            //kind of like SELECT COUNT(*) FROM Movies; in our database
            //this is a perfect example of a ORM
            //At the C# level, we are working with a DbSet (which is kind of like a fancy list) and the Count() method from LINQ
            //but at the SQL level, we are working with a SELECT COUNT(*) FROM Movies; query
            //EF Core is doing the work of translating our C# code into SQL for us and returning us the data we need.

            //to see all the movies
            //foreach(var dino in dinos)
            //{
            //    Console.WriteLine(dino.Name);
            //}

            //If we want to get the movies and their ratings:
            //JOIN
            //This comes from EnTIty Framework Core
            //
            // E.G.: For every Movie object we also get its associated Rating object  
            //Make a collection of movies but each movie knows the associated Rating object
            //                                      JOIN            Rating
            //                                      |               |  
            var moviesWithRatingsRolesAndActors = context.Movies.
                                                    // from our movie, please include the associated Rating object
                                                    Include(movie => movie.Rating).
                                                    //... and from our movie, please include the associated Roles List
                                                    Include(movie => movie.Roles).
                                                    //... THEN for each of the roles, please include the associated Actor object
                                                    ThenInclude(role => role.Actor);
            //the code above is and include of an include. Chained.


            //The code bellow is conceptually like: SELECT * FROM Movies;
            foreach (var movie in moviesWithRatingsRolesAndActors)//Movies is my property in a set related to my DbSet Movie class
            {
                if (movie.Rating == null)
                {
                    Console.WriteLine($"{movie.Title} - No rated.");
                }
                else
                {
                    //we receive instances of the Movie class we can use to output information such as each movie object's title: movie.Title
                    Console.WriteLine($"There is a movie named {movie.Title} - {movie.Rating.Description}.");
                }

                foreach (var role in movie.Roles)
                {
                    Console.WriteLine($"  {role.CharacterName} is played by {role.Actor.FullName}");
                }
            }

            //two INSERTS
            // var newMovie = new Movie
            // {
            //     Title = "SpaceBalls",
            //     PrimaryDirector = "Mel Brooks",
            //     Genre = "Comedy",
            //     YearReleased = 1987,
            //     RatingId = 2
            // };
            // context.Movies.Add(newMovie);//adding a movie
            // context.SaveChanges();//saving the changes

            // var otherNewMovie = new Movie
            // {
            //     Title = "Real Genius",
            //     PrimaryDirector = "I don't know",
            //     Genre = "Comedy",
            //     YearReleased = 1987,
            //     RatingId = 2
            // };

            // context.Movies.Add(otherNewMovie);//adding a movie
            // context.SaveChanges();//saving the changes

            //TWO INSERTS TOGETHER
            var newMovie = new Movie
            {
                Title = "SpaceBalls",
                PrimaryDirector = "Mel Brooks",
                Genre = "Comedy",
                YearReleased = 1987,
                RatingId = 2
            };

            var otherNewMovie = new Movie
            {
                Title = "Real Genius",
                PrimaryDirector = "I don't know",
                Genre = "Comedy",
                YearReleased = 1987,
                RatingId = 2
            };

            context.Movies.Add(newMovie);//adding a movie
            context.Movies.Add(otherNewMovie);//adding a movie
            context.SaveChanges();//saving the changes


            //UPDATING
            // Search for a movie by name. FirstOrDefault takes a function to use to compare the movies and returns the first record that matches, or if nothing matches, returns null.
            // This is the same as we used with LINQ against a List, but this time it is searching the database.
            //firstOrDefault generates a WHERE clause
            //SELECT * FROM "Movies" WHERE "Movies"."Title" = 'SpaceBalls';
            var existingMovie = context.Movies.FirstOrDefault(movie => movie.Title == "SpaceBalls");

            // If we found an existing movie.
            if (existingMovie != null)
            {
                // Change the title of this movie.
                existingMovie.Title = "SpaceBalls - the best movie ever";

                // Ask the context to save changes.
                //UPDATE "Movies" SET "Title" = 'SpaceBalls - the best movie ever' WHERE "Movies"."Id" = ------;
                context.SaveChanges();
            }

            //DELETING
            var existingMovieToDelete = context.Movies.FirstOrDefault(movie => movie.Title == "Cujo");

            // If we found an existing movie.
            if (existingMovieToDelete != null)
            {
                // Remove the existing movie from the collection
                context.Movies.Remove(existingMovieToDelete);

                // Ask the context to save changes, in this case deleting the record.
                context.SaveChanges();
            }
        }
    }
}
