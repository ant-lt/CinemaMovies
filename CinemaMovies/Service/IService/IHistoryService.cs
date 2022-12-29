using CinemaMovies.Models;
using CinemaMovies.Models.DTO;

namespace CinemaMovies.Service.IService
{
    public interface IHistoryService
    {
        PurchaseHistoryDto BuildPurchaseHistory(List<Purchase> purchases);
    }
}
