using AdminProSolutions.Domain.Interfaces.Authentication;
using AdminProSolutions.Domain.Interfaces.Miscellaneous;

namespace AdminProSolutions.Domain.Interfaces.Base
{
    public interface IUnitOfWork : IDisposable
    {
        IActiveDirectory ActiveDirectory { get; }
        IAuthetication Authetication { get; }
        IAudit Audit { get; }
        IUsers Users { get; }
        IGroups Groups { get; }
    }
}
 


