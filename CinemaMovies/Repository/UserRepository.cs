using CinemaMovies.Data;
using CinemaMovies.Models;
using CinemaMovies.Repositories.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace CinemaMovies.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly CinemaMoviesContext _db;

        public UserRepository(CinemaMoviesContext db)
        {
            _db = db;
        }

        /// <summary>
        /// Should return a flag indicating if a user with a specified username already exists
        /// </summary>
        /// <param name="username">Registration username</param>
        /// <returns>A flag indicating if username already exists</returns>
        public async Task<bool> IsUniqueUserAsync(string username)
        {
            var user = await _db.Users.FirstOrDefaultAsync(x => x.UserName == username);
            if (user == null)
            {
                return true;
            }
            return false;
        }

        public async Task<User> LoginAsync(User loginRequest)
        {
           
            var user = await _db.Users.FirstOrDefaultAsync(x => x.UserName.ToLower() == loginRequest.UserName.ToLower());


            if (user == null )
            {
                return new User
                {
                    UserName = "",
                    Role = ""
                };
            }

            user.Role = "";


            return user;
        }

        // Add RegistrationResponse (Should not include password)
        // Add adapter classes to map to wanted classes
        public async Task<User> RegisterAsync(User registrationRequest)
        {

            User user = new()
            {
                UserName = registrationRequest.UserName,
                Role = registrationRequest.Role,
            };

            _db.Users.Add(user);
            await _db.SaveChangesAsync();
            return user;
        }
    }

}