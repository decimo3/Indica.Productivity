namespace Indica.System.Domain.Entities
{
    public class Activity : EntityBase
    {
        public string ActivityName { get; set; }
        public int IdProject { get; set; }
        public bool IsBasketTruck { get; set; }
        public bool IsHalfPrice { get; set; }
        public bool IsSpecial { get; set; }
        public virtual Project Project { get; set; }
    }
}