namespace Indica.System.Domain.Entities
{
    public class Couple : EntityBase
    {
        public string IdFieldTeam { get; set; }
        public int Registry { get; set; }
        public bool IsLeader { get; set; }
    }
}
