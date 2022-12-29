using CinemaMovies.Models;
using CinemaMovies.Models.DTO;
using CinemaMovies.Service.IService;

namespace CinemaMovies.Service
{
    public class HistoryService : IHistoryService
    {
        public PurchaseHistoryDto BuildPurchaseHistory(List<Purchase> purchases)
        {
            var newPurchaseHistoryDto = new PurchaseHistoryDto()
            {
                Name = "",
                Purchases = new List<PurchaseDto>()
            };

            foreach (var purchase in purchases)
            {
                if (newPurchaseHistoryDto.Name == "") newPurchaseHistoryDto.Name = purchase.User.UserName;

                var newPurchaseDto = new PurchaseDto()
                {
                    PurchaseId = purchase.PurchaseId,
                    Date = purchase.DateTime,
                    TotalPrice = purchase.TotalPrice
                };
                newPurchaseHistoryDto.Purchases.Add(newPurchaseDto);
            }
            return newPurchaseHistoryDto;
        }
    }
}
