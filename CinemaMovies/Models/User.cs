using CinemaMovies.Enums;

namespace CinemaMovies.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public Role  Role { get; set; }
    }
}
