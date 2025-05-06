namespace Indica.System.Domain.Entities
{
    public class SummaryCount
    {
        public string FileName { get; set; }
        public DateOnly ReferenceDate { get; set; }
        public int ResourcesCount { get; set; }
        public int OrdersCount { get; set; }
    }
}