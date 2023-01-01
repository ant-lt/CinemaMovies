using CinemaMovies.Models;
using CinemaMovies.Models.DTO;

namespace CinemaMovies.Service
{
    public interface IUserWrapper
    {
        public User Bind(LoginRequestDTO loginRequest);
        public LoginResponseDTO BindToLoginDTO(User user);
        public User Bind(RegistrationRequestDTO registrationRequest);
        public RegistrationResponseDTO BindToRegistrationDTO(User user);
    }
}
