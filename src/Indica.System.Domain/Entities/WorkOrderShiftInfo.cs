namespace Indica.System.Domain.Entities
{
    public class WorkOrderShiftInfo : WorkOrderBase
    {
        public DateTime ShiftStartDate { get; set; }
        public string VehicleLabel { get; set; }
        public int IdLeaderRegistration { get; set; }
        public int IdAuxiliaryRegistration { get; set; }
        public int IdTechnicalRegistration { get; set; }
    }
}