namespace AdminProSolutions.Domain.Entities.Miscellaneous
{
    public class Audit
    {
        public static class Ops
        {
            public const string Create = "Create";
            public const string Update = "Update";
            public const string Delete = "Delete";
        }
        public Guid Id { get; set; }
        public string TableName { get; set; } = string.Empty;
        public DateTime DateTime { get; set; } = DateTime.Now;
        public string KeyValues { get; set; } = string.Empty;
        public string? OldValues { get; set; } = string.Empty;
        public string? NewValues { get; set; } = string.Empty;
        public string Operation { get; set; } = string.Empty;
        public string ChangeBy { get; set; } = string.Empty;
    }
}
