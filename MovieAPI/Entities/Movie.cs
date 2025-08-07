namespace MovieAPI.Entities
{
    public class Movie
    {
        public int MovieId { get; set; }
        public string MovieName { get; set; }
        public string Description { get; set; }
        public float IMDB { get; set; }
        public string Actors { get; set; }
        public int Year { get; set; }
    }
}
