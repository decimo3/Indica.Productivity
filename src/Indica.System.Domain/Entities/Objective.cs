namespace Indica.System.Domain.Entities
{
    public class Objective
    {
        public double IdContract { get; set; }
        public string ProcessName { get; set; }
        public bool IsBasketTruck { get; set; }
        public bool IsHalfPrice { get; set; }
        public decimal MonthlyProfitGoal { get; set; }
        public float FixedDivisorByMonth { get; set; }
        public int TargetOfTeamCountWorkday { get; set; }
        public int TargetOfTeamCountOnHoliday { get; set; }
        public int TargetOfExecutionsPerDay { get; set; }
    }
}