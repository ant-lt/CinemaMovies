using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace CinemaMovies.Models.DTO
{
    public class PurchaseHistoryDto
    {

        [Display(Name = "PurchaseItemId")]
        public int PurchaseItemId { get; set; }

        [Display(Name = "ItemId")]
        public int ItemId { get; set; }

        [Display(Name = "Count")]
        public int Count { get; set; }

        [Display(Name = "MovieId")]
        public int MovieId { get; set; }





    }
}
