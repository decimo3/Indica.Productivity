namespace Indica.System.Application.DTO
{
    public class DamageToProjectDTO : EntityBaseDTO
    {
        public string Damage { get; set; }
        public string Description { get; set; }
        public int IdProject { get; set; }
    }
}