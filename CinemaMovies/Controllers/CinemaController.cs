using CinemaMovies.Models;
using CinemaMovies.Models.DTO;
using CinemaMovies.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CinemaMovies.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CinemaController : ControllerBase
    {
        private readonly ILogger<CinemaController> _logger;
        private readonly IPurchaseRepository _purchaseRepo;


        public CinemaController(ILogger<CinemaController> logger, IPurchaseRepository purchaseRepo)
        {
            _logger = logger;
            _purchaseRepo = purchaseRepo;
        }


        /// <summary>
        /// Metodas sugrazina viena pirkini is duomenu bazes pagal paduota id
        /// </summary>
        /// <returns>Grazina rezultata??? ar veikia dar nezinom</returns>
        /// <response code="200">VISKAS OK jei 200, sekmingai rasta ir grazinta ieskoma knyga pagal id</response>
        /// <response code="400">buvo gautas blogas kreipimasis</response>
        /// <response code="404">Toks puslapis/adresas nerastas</response>
        /// <response code="500">Ciua jau serverio klaidos kodas!</response>
        [HttpGet("GautiPirkinyPagal", Name = "GetReservation")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<PurchaseHistoryDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<PurchaseHistoryDto>> GetPurchaseHistory(int userId)
        {
            _logger.LogInformation("Metodas Get pagal (UserId = {0}) iskvietimo laikas buvo - {1} ", userId, DateTime.Now);
            try
            {
                if (userId == 0)
                {
                    return BadRequest();
                }
              
                var history = await _purchaseRepo.GetAsync(r => r.PurchaseId == userId);
               
                return Ok(history);

            }
            catch (Exception e)
            {
                _logger.LogError(e, "Metodas Get gauti PurchaseHistory pagal id(userId = {0}) nuluzo del serverio klaidos tokiu laiku - {1} ", userId, DateTime.Now);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }











    }
}
