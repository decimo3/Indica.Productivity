namespace Indica.System.Application.DTO
{
    public class ObjectiveDTO : EntityBaseDTO
    {
        public int IdContractProject { get; set; }
        public bool IsBasketTruck { get; set; }
        public bool IsHalfPrice { get; set; }
        public bool IsEspecial { get; set; }
        public float MonthlyProfitGoal { get; set; }
        public float FixedDivisorByMonth { get; set; }
        public int TargetOfTeamCountOnWorkday { get; set; }
        public int TargetOfTeamCountOnHoliday { get; set; }
        public int TargetOfExecutionsPerDay { get; set; }
    }
}