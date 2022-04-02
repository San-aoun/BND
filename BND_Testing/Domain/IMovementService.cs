using BND_Testing.Dto;
using System.Threading.Tasks;

namespace BND_Testing.Domain
{
    public interface IMovementService
    {
        Task<MovementDto> GetMovements(int productId);
    }
}
