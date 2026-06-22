using Indica.Productivity.Shared;
namespace Indica.Productivity.Application.DTO
{
    public class FieldTeamDTO : EntityBaseDTO
    {
        [Alias("DATA")]
        public DateOnly Date { get; set; } = DateOnly.FromDateTime(DateTime.Now);
        [Alias("ADESIVO LIGHT")]
        public int Order { get; set; }
        [Alias("PLACA")]
        public string Plate { get; set; }
        [Alias("RECURSO")]
        public string Resource { get; set; }
        [Alias("ATIVIDADE")]
        public string ActivityName { get; set; }
        [Alias("MATRÍCULA 01")]
        public int EmployerRegistry1 { get; set; }
        [Alias("EXECUTOR 01")]
        public string EmployerName1 { get; set; }
        [Alias("MATRÍCULA 02")]
        public int EmployerRegistry2 { get; set; }
        [Alias("EXECUTOR 02")]
        public string EmployerName2 { get; set; }
        [Alias("TELEFONE EQUIPE")]
        public long Cellphone { get; set; }
        [Alias("MATRICULA SUP")]
        public int SupervisorRegistry { get; set; }
        [Alias("SUPERVISOR EMPREITEIRA")]
        public string SupervisorName { get; set; }
        [Alias("ÁREA DE ATUAÇÃO")]
        public string WorkArea { get; set; }
        public bool IsConsidered { get; set; } = true;
        public string Abreviate
        {
            get
            {
                return Resource
                        .Trim()
                        .Replace('–', '-')
                        .Replace('\u00A0', '\u0020')
                        .Replace("  ", " ")
                        .Replace(" - Corte", "C")
                        .Replace(" - Religa", "R")
                        .Replace(" - Vistoriador ", "V")
                        .Replace(" - Indica", "")
                        .Replace(" - Equipe ", "")
                        .Replace(" - ", "")
                        .Split(' ', 2)
                        .First();
            }
        }
    }
}
