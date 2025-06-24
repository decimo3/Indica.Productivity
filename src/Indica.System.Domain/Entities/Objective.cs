namespace Indica.System.Domain.Entities
{
    public class Objective : EntityBase
    {
        public int IdContract { get; set; }
        public int IdProcess { get; set; }
        public bool IsBasketTruck { get; set; }
        public bool IsHalfPrice { get; set; }
        public bool IsEspecial { get; set; }
        public decimal MonthlyProfitGoal { get; set; }
        public float FixedDivisorByMonth { get; set; }
        public int TargetOfTeamCountOnWorkday { get; set; }
        public int TargetOfTeamCountOnHoliday { get; set; }
        public int TargetOfExecutionsPerDay { get; set; }
    }
}