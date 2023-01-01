using CinemaMovies.Models;
using CinemaMovies.Repositories.IRepository;

namespace CinemaMovies.Repository.IRepository
{
    public interface IPurchaseRepository : IRepository<Purchase>
    {
        Task<Purchase> UpdateAsync(Purchase purchase);
    }
}
