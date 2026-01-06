namespace Indica.System.Domain.Entities
{
    public class ChangeLog
    {
        public DateTime Timestamp { get; set; }
        public int Registry { get; set; }
        public string TableName { get; set; }
        public string VerbOfOperation { get; set; }
        public string PreviousValue { get; set; }
        public string CurrentValue { get; set; }
    }
}