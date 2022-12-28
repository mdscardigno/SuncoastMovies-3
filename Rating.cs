using System.Collections.Generic;

namespace SuncoastMovies
{
    public class Rating
    {
        public int Id { get; set; }
        public string Description { get; set; }

        //RELATING OBJECTS TOGETHER
        public List<Movie> Movies { get; set; }//we should be able from a Rating to get a list of all the  Movies that have that Rating
    }
}