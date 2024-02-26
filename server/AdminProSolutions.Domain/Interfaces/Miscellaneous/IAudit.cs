using AdminProSolutions.Domain.Entities.Miscellaneous;
using AdminProSolutions.Domain.Interfaces.Base;
using AdminProSolutions.Domain.Model;

namespace AdminProSolutions.Domain.Interfaces.Miscellaneous
{
    public interface IAudit : IRepository<Audit>
    {
        Audit? GetByGuid(Guid id);
        IQueryable<Audit> GetAllByFilter(AuditFilterDto filter);
    }
}
