namespace Indica.Productivity.Application.DTO
{
    public class ContractDTO : EntityBaseDTO
    {
        public long ContractNumber { get; set; }
        public int AdditiveNumber { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly FinalDate { get; set; }
    }
}
