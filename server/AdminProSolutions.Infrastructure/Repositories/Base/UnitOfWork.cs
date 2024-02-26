using AdminProSolutions.Domain.Interfaces.Authentication;
using AdminProSolutions.Domain.Interfaces.Base;
using AdminProSolutions.Domain.Interfaces.Messenger;
using AdminProSolutions.Domain.Interfaces.Miscellaneous;
using AdminProSolutions.Infrastructure.Data;

namespace AdminProSolutions.Infrastructure.Repositories.Base
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;
        public IActiveDirectory ActiveDirectory { get; }
        public IAuthetication Authetication { get; }
        public IAudit Audit { get; }
        public IUsers Users { get; }
        public IGroups Groups { get; }
        public IEmail Email { get; }

        public UnitOfWork(DataContext context, IUsers users, IGroups groups, IAudit audit, IAuthetication authetication, IActiveDirectory activeDirectory, IEmail email)
        {
            _context = context;
            Authetication = authetication;
            Audit = audit;
            Users = users;
            Groups = groups;
            ActiveDirectory = activeDirectory;
            Email = email;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
    }
}
