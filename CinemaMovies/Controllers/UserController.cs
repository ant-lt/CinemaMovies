using CinemaMovies.Models;
using CinemaMovies.Models.DTO;
using CinemaMovies.Repositories.IRepository;
using CinemaMovies.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace CinemaMovies.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepo;
        private readonly IUserWrapper _userWrapper;
        private readonly ILogger<UserController> _logger;


        public UserController(IUserRepository userRepo, ILogger<UserController> logger, IUserWrapper userWrapper)
        {
            _userRepo = userRepo;
            _logger = logger;
            _userWrapper = userWrapper;
        }

        /// <summary>
        /// Login to cinema system
        /// </summary>
        /// <param name="loginData"></param>
        /// <returns>Status code</returns>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(LoginResponseDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces(MediaTypeNames.Application.Json)]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDTO loginData)
        {

            _logger.LogInformation($"Login with username: {loginData.UserName}");

            try
            {
                var loginUser = await _userRepo.LoginAsync( _userWrapper.Bind(loginData) );

                if (loginUser == null )
                {
                    return BadRequest(new { message = "Username or password is incorrect" });
                }


                return Ok(_userWrapper.BindToLoginDTO(loginUser));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"{DateTime.Now} HttpPost Login nuluzo.");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        /// <summary>
        /// New user registration to cinema system
        /// </summary>
        /// <param name="registrationData"></param>
        /// <returns>Status code</returns>
        /// <response code="200">OK</response>
        /// <response code="400">Bad request</response>
        [HttpPost("register")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RegistrationResponseDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<IActionResult> Register([FromBody] RegistrationRequestDTO registrationData)
        {
            _logger.LogInformation($"Register with username: {registrationData.UserName}  role: {registrationData.Role}");

            try
            {
                var isUserNameUnique = await _userRepo.IsUniqueUserAsync(registrationData.UserName);

                if (!isUserNameUnique)
                {
                    return BadRequest(new { message = "Username already exists" });
                }

                var user = await _userRepo.RegisterAsync(_userWrapper.Bind(registrationData));

                if (user == null)
                {
                    return BadRequest(new { message = "Error while registering" });
                }

                return Ok(_userWrapper.BindToRegistrationDTO(user));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"{DateTime.Now} HttpPost Register nuluzo.");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}

