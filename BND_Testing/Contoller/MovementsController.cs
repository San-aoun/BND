using BND_Testing.Dto;
using BND_Testing.Model;
using BND_Testing.Service;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BND_Testing.Contoller
{
    [ApiController]
    public class MovementsController : Controller
    {
        [HttpGet]
        [Route("Movements/{productId}/{filterType}")]
        [ProducesResponseType(typeof(IEnumerable<MovementDto>), statusCode: 200)]
        public IActionResult GetMovements(int productId, EnumGetMovementFilter filterType)
        {
            var _movementService = new MovementService();
            MovementDto result =  _movementService.GetMovementsForOverview(productId, filterType);

            if (result is null)
                return NotFound();

            return Ok();
        }
    }
}
