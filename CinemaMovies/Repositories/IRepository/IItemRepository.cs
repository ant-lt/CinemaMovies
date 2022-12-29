using CinemaMovies.Models;

namespace CinemaMovies.Repositories.IRepository
{
    public interface IItemRepository : IRepository<Item>
    {
        Item Update(Item item);
    }
}
