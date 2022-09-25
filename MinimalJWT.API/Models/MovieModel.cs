namespace MinimalJWT.API.Models
{
    public class MovieModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public double Rating { get; set; } = 0;
    }
}
