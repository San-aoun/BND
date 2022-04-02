using BND_Testing.Model;

namespace BND_Testing.Dto
{
    public class MovementDto
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public MovementResponse Movements { get; init; }
    }
}
