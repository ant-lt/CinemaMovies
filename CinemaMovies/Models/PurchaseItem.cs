using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace CinemaMovies.Models
{
    public class PurchaseItem
    {
        [Required]
        [Display(Name = "PirkinioId")]
        public int PurchaseId { get; set; }

        [Display(Name = "Statusas")]
        public string PurchaseStatus { get; set; }

        [Display(Name = "UserioId")]
        public int UserId { get; set; }

        [Display(Name = "PrekiuSarasas")]
        public PurchaseItem PurchaseItems { get; set; }

        [Display(Name = "VisoKaina")]
        public double TotalPrice { get; set; }

        [Display(Name = "Data")]
        public DateTime DateTime { get; set; }







    }
}
