namespace Indica.System.Domain.Entities
{
    public class SupervisorContract : EntityBase
    {
        public int Registry { get; set; }
        public int ContractNumber { get; set; }
        public int AdditiveNumber { get; set; }
    }
}
