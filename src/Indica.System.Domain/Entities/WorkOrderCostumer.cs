namespace Indica.System.Domain.Entities
{
    public class WorkOrderCostumer : EntityBase
    {
        public long InstallationNumber { get; set; }
        public string CostumerName { get; set; }
        public string CostumerAddress { get; set; }
        public string BuildingNumberOrAcronym { get; set; }
        public string NumberComplement { get; set; }
        public string SubNeighborhood { get; set; }
        public int WorkAreaNumber { get; set; }
        public string CostumerCity { get; set; }
        public string CostumerState { get; set; }
        public int CostumerPostalCode { get; set; }
        public long CostumerTelephone { get; set; }
        public long CostumerCellphone { get; set; }
        public string CostumerEmail { get; set; }
        public int IdConnectionType { get; set; }
        public bool IsFoundCoordinateStatus { get; set; }
        public double CoordinateX { get; set; }
        public double CoordinateY { get; set; }
        public int IdCoordinateAccuracy { get; set; }
        public virtual WorkOrderPhase Phase { get; set; }
        public virtual WorkOrderAccuracy Accuracy { get; set; }
    }
}