using CinemaMovies.Models;
using CinemaMovies.Repositories.IRepository;
using CinemaMovies.Repositories;
using CinemaMovies.Repository.IRepository;
using CinemaMovies.Data;

namespace CinemaMovies.Repository
{
    public class MoviesRepository : Repository<Movie>, IMoviesRepository
    {
        private readonly CinemaMoviesContext _db;

        public MoviesRepository(CinemaMoviesContext db) : base(db)
        {
            _db = db;
        }

        public async Task<Movie> UpdateAsync(Movie movie)
        {
            _db.Movies.Update(movie);
            await _db.SaveChangesAsync();
            return movie;
        }
    }
}
