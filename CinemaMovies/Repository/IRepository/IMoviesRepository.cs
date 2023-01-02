using CinemaMovies.Models;
using CinemaMovies.Repositories.IRepository;

namespace CinemaMovies.Repository.IRepository
{
    public interface IMoviesRepository : IRepository<Movie>
    {
        Task<Movie> UpdateAsync(Movie movie);
    }
}
