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
        // public int RatingId { get; set; }
    }
}