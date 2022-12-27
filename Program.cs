﻿using System;
using System.Linq;

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
            //At the C# level, we are working with a DbSet and the Count() method from LINQ
            //but at the SQL level, we are working with a SELECT COUNT(*) FROM Movies; query
            //EF Core is doing the work of translating our C# code into SQL for us and returning us the data we need.

        }
    }
}
