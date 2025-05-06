namespace Indica.System.Domain.Entities
{
    public class Process
    {
        public string IdActivity { get; set; }
        public string ActivityName { get; set; }
        public bool IsBasketTruck { get; set; }
        public bool IsHalfPrice { get; set; }
        public string ProcessName { get; set; }
        public bool IsSpecial { get; set; }
    }
}