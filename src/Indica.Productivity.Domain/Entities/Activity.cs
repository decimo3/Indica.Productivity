namespace Indica.System.Domain.Entities
{
    public class Activity : EntityBase
    {
        public string ActivityName { get; set; }
        public int IdProject { get; set; }
        public virtual Project Project { get; set; }
    }
}