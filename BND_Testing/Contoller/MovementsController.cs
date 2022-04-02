using BND_Testing.Domain;
using BND_Testing.Dto;
using BND_Testing.Model;
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
        public async Task<IActionResult> GetMovements(int productId)
        {
            var filterType = EnumGetMovementFilter.Free;

            MovementDto result = await _movementService.GetMovementsForOverview(productId, filterType);

            if (result is null)
                return NotFound();

            return Ok(result);
        }
    }
}
