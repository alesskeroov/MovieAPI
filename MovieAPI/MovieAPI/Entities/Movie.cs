namespace MovieAPI.Entities
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public float IMDB { get; set; }
        public string Director { get; set; }
        public string GenreId { get; set; }
        public Genre Genre { get; set; }
    }
}
