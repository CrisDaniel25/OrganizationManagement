using AdminProSolutions.Domain.Entities.Miscellaneous;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Newtonsoft.Json;

namespace AdminProSolutions.Domain.Dtos.Miscellaneous
{
    public class AuditDto
    {
        public Guid Id { get; set; }
        public string TableName { get; set; } = string.Empty;
        public DateTime DateTime { get; set; }
        public string Date => string.Format("{0:MMMM d, yyyy}", DateTime);
        public string KeyValues { get; set; } = string.Empty;
        public string OldValues { get; set; } = string.Empty;
        public string NewValues { get; set; } = string.Empty;
        public string Operation { get; set; } = string.Empty;
        public string ChangeBy { get; set; } = string.Empty;
    }
}
