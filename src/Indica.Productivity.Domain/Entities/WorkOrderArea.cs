namespace Indica.System.Domain.Entities
{
    public class WorkOrderArea : EntityBase
    {
        public int AreaNumber { get; set; }
        public string AreaName { get; set; }
        public int IdRegion { get; set; }
        public virtual FieldTeamRegional Regional { get; set; }
    }
}
