using System.Linq.Expressions;

namespace AdminProSolutions.Domain.Interfaces.Base
{
    public interface IRepository<T> where T : class
    {
        IReadOnlyList<T> GetAll();
        IReadOnlyCollection<T> Find(Expression<Func<T, bool>> predicate);
        T? GetById(int id);
        T Add(T entity);
        IReadOnlyCollection<T> AddRange(IEnumerable<T> entities);
        T Update(T entity);
        IReadOnlyCollection<T> UpdateRange(IEnumerable<T> entities);
        void Delete(T entity);
        void DeleteRange(IEnumerable<T> entities);
    }
}
