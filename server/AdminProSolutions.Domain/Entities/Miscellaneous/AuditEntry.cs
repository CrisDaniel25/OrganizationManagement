using Microsoft.EntityFrameworkCore.ChangeTracking;
using Newtonsoft.Json;

namespace AdminProSolutions.Domain.Entities.Miscellaneous
{
    public class AuditEntry
    {
        public AuditEntry(EntityEntry entry) => Entry = entry;
        
        public EntityEntry Entry { get; }
        public string TableName { get; set; }
        public Dictionary<string, object> KeyValues { get; } = new Dictionary<string, object>();
        public Dictionary<string, object> OldValues { get; } = new Dictionary<string, object>();
        public Dictionary<string, object> NewValues { get; } = new Dictionary<string, object>();
        public List<PropertyEntry> TemporaryProperties { get; } = new List<PropertyEntry>();
        public bool HasTemporaryProperties => TemporaryProperties.Any();
        public string Operation { get; set; } = string.Empty;
        public string ChangeBy { get; set; } = string.Empty;

        public Audit ToAudit()
        {
            Audit audit = new Audit
            {
                TableName = TableName,
                DateTime = DateTime.UtcNow,
                KeyValues = JsonConvert.SerializeObject(KeyValues),
                OldValues = OldValues.Count == 0 ? null : JsonConvert.SerializeObject(OldValues),
                NewValues = NewValues.Count == 0 ? null : JsonConvert.SerializeObject(NewValues),
                Operation = Operation,
                ChangeBy = ChangeBy
            };
            return audit;
        }
    }
}
