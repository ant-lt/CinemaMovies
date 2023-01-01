using CinemaMovies.Models;
using CinemaMovies.Models.DTO;

namespace CinemaMovies.Service
{
    public class UserWrapper : IUserWrapper
    {
        public User Bind(LoginRequestDTO loginRequest)
        {
            return new User
            {
                UserName = loginRequest.UserName
            };
        }

        public LoginResponseDTO BindToLoginDTO(User user)
        {
            return new LoginResponseDTO
            {
                UserName = user.UserName,
                Role = user.Role
            };
        }

        public User Bind(RegistrationRequestDTO registrationRequest)
        {
            return new User
            {
                UserName = registrationRequest.UserName,
                Role = registrationRequest.Role
            };
        }

        public RegistrationResponseDTO BindToRegistrationDTO(User user)
        {
            return new RegistrationResponseDTO
            {
                UserName = user.UserName,
                Role = user.Role
            };
        }
    }
}
