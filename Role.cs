namespace SuncoastMovies
{
    public class Role
    {
        public int Id { get; set; }
        public string CharacterName { get; set; }
        //Other properties (Foreign Keys)
        public int MovieId { get; set; }
        public int ActorId { get; set; }

        //RELATING OBJECTS TOGETHER
        public Movie Movie { get; set; }//The Movie object that this role is associated with
        public Actor Actor { get; set; }//The Actor object that this role is associated with

        //we can have objects that are properties of other objects
        //an object can have more than just int, string, bool, etc. as properties, it can have other objects as properties.
        //they can have Lists as properties 

        //a Role is related to a Movie and an Actor
    }
}