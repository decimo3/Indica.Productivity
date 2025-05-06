namespace Indica.System.Domain.Entities
{
    public class Fieldteam : EntityBase
    {
        public string IdFieldteam { get; set; }
        public DateOnly Date { get; set; }
        public int OrderNumber { get; set; }
        public string Plate { get; set; }
        public string Resource { get; set; }
        public string ActivityName { get; set; }
        public virtual Process Activity { get; set; }
        public string IdCouple { get; set; }
        public virtual Couple Couple { get; set; }
        public long Cellphone { get; set; }
        public string Region { get; set; }
        public bool IsSpecial { get; set; }
        public double IdContract { get; set; }
        public virtual Contract Contract { get; set; }
    }
}