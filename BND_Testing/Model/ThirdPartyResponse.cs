namespace BND_Testing.Model
{
    public class ThirdPartyResponse
    {
        public string Account { get; init; }
        public decimal Amount { get; init; }
        public string AccountFrom { get; init; }
        public string AccountTo { get; init; }
        public int PageSize { get; init; }
        public int PageNumber { get; init; }
        public EnumMovementType MovementType { get; init; }
    }
}
