namespace Indica.System.Domain.Entities
{
    public class Contract : EntityBase
    {
        public long ContractNumber { get; set; }
        public int AdditiveNumber { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly FinalDate { get; set; }
    }
}