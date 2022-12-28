using System.Collections.Generic;

namespace SuncoastMovies
{
    public class Movie
    {
        //names will align with the database table
        public int Id { get; set; }
        public string Title { get; set; }//When we ask for Title, we will get back a string
        public string PrimaryDirector { get; set; }
        public int YearReleased { get; set; }
        public string Genre { get; set; }
        public int RatingId { get; set; }

        //RELATING OBJECTS TOGETHER
        //Accessor property that gives me back the Rating object that this movie
        //
        //
        //     Name of the class (the thing I will get back is a Raging object)
        //       |    
        //       |      Name of the property or this movie rating
        //       |      |    
        //       v      v
        public Rating Rating { get; set; }//When we ask for Rating, we will get back a Rating object

        //One to Many Relationship from Movie => Role
        public List<Role> Roles { get; set; }//When we ask for Roles, we will get back a list of Role objects
        //a movie is related to a Rating and to a Role
    }
}