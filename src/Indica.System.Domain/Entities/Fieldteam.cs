namespace Indica.System.Domain.Entities
{
    public class Fieldteam : EntityBase
    {
        public string IdFieldteam { get; set; }
        public DateOnly Date { get; set; }
        public int Order { get; set; }
        public string Plate { get; set; }
        public string Resource { get; set; }
        public string IdActivity { get; set; }
        public long Cellphone { get; set; }
        public string IdRegion { get; set; }
        public bool IsSpecial { get; set; }
        public bool IsConsidered { get; set; }
    }
}