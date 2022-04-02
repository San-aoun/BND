using BND_Testing.Domain;
using BND_Testing.Dto;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BND_Testing.Contoller
{
    [ApiController]
    public class MovementsController : Controller
    {
        private readonly IMovementService _movementService;
        [HttpGet]
        [Route("Movements/{productId}")]
        [ProducesResponseType(typeof(IEnumerable<MovementDto>), statusCode: 200)]
        public async Task<IActionResult> GetMovementsForOverview(int productId)
        {
            MovementDto result = await _movementService.GetMovements(productId);

            if (result is null)
                return NotFound();

            return Ok(result);
        }
    }
}
