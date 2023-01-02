using CinemaMovies.Data;
using CinemaMovies.Models;
using CinemaMovies.Repositories;
using CinemaMovies.Repository.IRepository;
using System.Linq.Expressions;

namespace CinemaMovies.Repository
{
    public class MovieReviewRepository : Repository<MovieReview>, IMovieReviewRepository
    {
        private readonly CinemaMoviesContext _db;

        public MovieReviewRepository(CinemaMoviesContext db) : base(db)
        {
            _db = db;
        }

        public async Task<MovieReview> UpdateAsync(MovieReview movieReview)
        {
            _db.MovieReviews.Update(movieReview);
            await _db.SaveChangesAsync();
            return movieReview;
        }
    }
}
