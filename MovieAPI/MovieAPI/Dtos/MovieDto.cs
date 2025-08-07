namespace MovieAPI.Dtos
{
    public class MovieDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public float Imdb { get; set; }
        public string Director { get; set; }
        public string GenreName { get; set; } = "Unknown";
    }
}
