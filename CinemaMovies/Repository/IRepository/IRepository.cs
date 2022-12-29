using System.Linq.Expressions;

namespace CinemaMovies.Repositories.IRepository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>? filter = null);
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter, bool tracked = true);
        Task CreateAsync(TEntity entity);
        Task RemoveAsync(TEntity entity);
        Task SaveAsync();
    }
}
