namespace SuncoastMovies
{
    public class Movie
    {
        //names will align with the database table
        public int Id { get; set; }
        public string Title { get; set; }
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
        public Rating Rating { get; set; }

        public List<Role> Roles { get; set; }

    }
}