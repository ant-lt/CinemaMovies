namespace CinemaMovies.Models
{
    public class MovieReview
    {
        public int MowieReviewId { get; set; }
        public int MovieId { get; set; }
        public int UserId { get; set; }
        public int UserRaiting { get; set; }
        public string ReviewText { get; set; }


    }
}
