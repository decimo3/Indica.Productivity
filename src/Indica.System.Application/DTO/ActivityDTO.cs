namespace Indica.System.Application.DTO
{
    public class ActivityDTO : EntityBaseDTO
    {
        public string ActivityName { get; set; }
        public int IdProject { get; set; }
        public bool IsBasketTruck { get; set; }
        public bool IsHalfPrice { get; set; }
        public bool IsSpecial { get; set; }
    }
}