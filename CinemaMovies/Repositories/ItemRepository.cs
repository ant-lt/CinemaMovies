using CinemaMovies.Models;
using CinemaMovies.Repositories.IRepository;

namespace CinemaMovies.Repositories
{
    public class ItemRepository : Repository<Item>, IItemRepository
    {
        private readonly ItemContext _db;

        public ItemRepository(ItemContext db) : base(db)
        {
            _db = db;
        }

        public Item Update(Item item)
        {

            item.Updated = DateTime.Now;
            _db.Items.Update(item);
            _db.SaveChanges();
            return item;
        }
    }
}
