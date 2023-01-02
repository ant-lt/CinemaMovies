using CinemaMovies.Models;
using CinemaMovies.Repositories.IRepository;

namespace CinemaMovies.Repository.IRepository
{
    public interface IMovieReviewRepository : IRepository<MovieReview>
    {
        Task<MovieReview> UpdateAsync(MovieReview movie);
    }
}
