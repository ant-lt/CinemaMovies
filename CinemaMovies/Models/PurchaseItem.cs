using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace CinemaMovies.Models
{
    public class PurchaseItem
    {
        [Required]
        [Display(Name = "PurchaseItemId")]
        public int PurchaseItemId { get; set; }

        [Display(Name = "ItemId")]
        public int ItemId { get; set; }
        public Item Item { get; set; }

        [Display(Name = "Count")]
        public int Count { get; set; }

        [Display(Name = "MovieId")]
        public int MovieId { get; set; }



    }
}
