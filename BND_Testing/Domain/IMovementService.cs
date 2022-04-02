using BND_Testing.Dto;
using BND_Testing.Model;
using System.Threading.Tasks;

namespace BND_Testing.Domain
{
    public interface IMovementService
    {
        Task<MovementDto> GetMovementsForOverview(int productId, EnumGetMovementFilter filter);
    }
}
