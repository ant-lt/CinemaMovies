using CinemaMovies.Data;
using CinemaMovies.Models;
using CinemaMovies.Repositories.IRepository;

namespace CinemaMovies.Repositories
{
    public class ItemRepository : Repository<Item>, IItemRepository
    {
        private readonly CinemaMoviesContext _db;

        public ItemRepository(CinemaMoviesContext db) : base(db)
        {
            _db = db;
        }

        public Item Update(Item item)
        {
            _db.Items.Update(item);
            _db.SaveChanges();
            return item;
        }
    }
}
