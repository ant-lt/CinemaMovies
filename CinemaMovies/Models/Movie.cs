namespace CinemaMovies.Models
{
    public class Movie
    {
        public int MovieId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Author { get; set; }
        public int MovieRating { get; set; }
        public List<MovieReview> MovieReview { get; set; }



    }
}
