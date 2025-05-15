namespace Indica.System.Domain.Entities
{
    public class Contract : EntityBase
    {
        public long ContractNumber { get; set; }
        public int AdditiveNumber { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly FinalDate { get; set; }
        public Contract(long contractNumber, int additiveNumber, DateOnly startDate, DateOnly finalDate)
        {
            ContractNumber = contractNumber;
            AdditiveNumber = additiveNumber;
            StartDate = startDate;
            FinalDate = finalDate;
            IdContract = contractNumber + (additiveNumber * 0.01);
        }
    }
}