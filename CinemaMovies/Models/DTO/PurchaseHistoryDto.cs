using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace CinemaMovies.Models.DTO
{
    public class PurchaseHistoryDto
    {

        public string Name;

        public List<PurchaseDto> Purchases;

    }
}
