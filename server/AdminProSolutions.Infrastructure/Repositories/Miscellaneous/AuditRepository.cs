using AdminProSolutions.Domain.Entities.Miscellaneous;
using AdminProSolutions.Domain.Interfaces.Miscellaneous;
using AdminProSolutions.Domain.Model;
using AdminProSolutions.Infrastructure.Data;
using AdminProSolutions.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace AdminProSolutions.Infrastructure.Repositories.Miscellaneous
{
    public class AuditRepository : Repository<Audit>, IAudit
    {
        public AuditRepository(DataContext context) : base(context) { }

        public IQueryable<Audit> GetAllByFilter(AuditFilterDto filter)
        {
            IQueryable<Audit> res = _context.Audits;

            if (!string.IsNullOrWhiteSpace(filter.KeyValues))
            {
                res = res.Where(s => s.KeyValues.Replace("\"", "") == filter.KeyValues.Replace("\"", ""));
            }

            if (!string.IsNullOrWhiteSpace(filter.TableName))
            {
                res = res.Where(s => s.TableName.Replace("\"", "") == filter.TableName.Replace("\"", ""));
            }

            return res.AsNoTracking().OrderByDescending(x => x.DateTime);
        }

        public Audit? GetByGuid(Guid id)
        {
            var record = _context.Audits.Find(id);
            return record;
        }

    }
}
