using System;

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

        }
    }
}
