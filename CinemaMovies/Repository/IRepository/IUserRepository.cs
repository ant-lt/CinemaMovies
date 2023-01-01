using CinemaMovies.Models;
using CinemaMovies.Models.DTO;

namespace CinemaMovies.Repositories.IRepository
{
    public interface IUserRepository
    {
        Task<bool> IsUniqueUserAsync(string username);
        Task<User> LoginAsync(User loginRequest);
        Task<User> RegisterAsync(User registrationRequest);
    }
}
