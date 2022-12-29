using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace CinemaMovies.Models
{
    // Temp comment
    public class Purchase
    {

        [Required]
        [Display(Name = "PirkinioId")]
        public int PurchaseId { get; set; }

        [Display(Name = "Statusas")]
        public string PurchaseStatus { get; set; }

        [Display(Name = "UserioId")]
        public int UserId { get; set; }
        public virtual User User { get; set; }

        [Display(Name = "PrekiuSarasas")]
        public List<PurchaseItem> PurchaseItems { get; set; }

        [Display(Name = "VisoKaina")]
        public double TotalPrice { get; set; }

        [Display(Name = "Data")]
        public DateTime DateTime { get; set; }
    }
}
