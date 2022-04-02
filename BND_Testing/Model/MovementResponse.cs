namespace BND_Testing.Model
{
    public class MovementResponse
    {
        public string Account { get; set; }
        public EnumMovementType MovementType { get; set; }
        public decimal? Amount { get; set; }
        public string AccountFrom { get; set; }
        public string AccountTo { get; set; }

    }
}
