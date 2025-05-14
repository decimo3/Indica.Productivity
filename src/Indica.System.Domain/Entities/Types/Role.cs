namespace Indica.System.Domain.Entities.Types
{
    public class Role : EntityBase
    {
        public int IdRole { get; set; }
        public string RoleName { get; set; }
        public string Description { get; set; }
    }
}
