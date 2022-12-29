namespace CinemaMovies.Models.DTO
{
    public class InvoiceDto
    {
        public DateTime Date { get; set; }
        public string Name { get; set; }
        public string Company { get; set; } = "CinemaMoviesCo";
        public string Address { get; set; } = "CinemaMoviesCo Address";
        public List<PurchaseItem> PurchaseItems { get; set; } = new List<PurchaseItem>();
    }
}
