namespace Indica.System.Application.DTO
{
    public class FieldTeamDTO : EntityBaseDTO
    {
        public string IdFieldTeam { get; set; }
        public DateOnly Date { get; set; }
        public int Order { get; set; }
        public string Plate { get; set; }
        public string Resource { get; set; }
        public string ActivityName { get; set; }
        public int EmployerRegistry1 { get; set; }
        public string EmployerName1 { get; set; }
        public int EmployerRegistry2 { get; set; }
        public string EmployerName2 { get; set; }
        public long Cellphone { get; set; }
        public int SupervisorRegistry { get; set; }
        public string SupervisorName { get; set; }
        public string WorkArea { get; set; }
    }
}
