using System.Linq.Expressions;
using AdminProSolutions.Domain.Interfaces.Base;
using AdminProSolutions.Infrastructure.Data;

namespace AdminProSolutions.Infrastructure.Repositories.Base
{
    public class Repository <T> : IRepository<T> where T : class
    {
        protected readonly DataContext _context;

        public Repository(DataContext context) => _context = context;

        public IReadOnlyList<T> GetAll()
        {
            try
            {
                return _context.Set<T>().ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception in Add() Method Repository: {ex.Message}");
                throw;
            }
        }

        public IReadOnlyCollection<T> Find(Expression<Func<T, bool>> predicate)
        {
            try
            {
                return _context.Set<T>().Where(predicate).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception in Find() Method Repository: {ex.Message}");
                throw;
            }
        }

        public T? GetById(int id)
        {
            try
            {
                return _context.Set<T>().Find(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception in GetById() Method Repository: {ex.Message}");
                throw;
            }
        }

        public T Add(T entity)
        {
            try
            {
                _context.Set<T>().Add(entity);
                _context.SaveChanges();

                return entity;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception in Add() Method Repository: {ex.Message}");
                throw;
            }
        }

        public IReadOnlyCollection<T> AddRange(IEnumerable<T> entities)
        {
            try
            {
                _context.AddRange(entities);
                _context.SaveChanges();

                return entities.ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception in AddRange() Method Repository: {ex.Message}");
                throw;
            }
        }

        public T Update(T entity)
        {
            try
            {
                _context.Set<T>().Update(entity);
                _context.SaveChanges();
                
                return entity;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception in Update() Method Repository: {ex.Message}");
                throw;
            }
        }

        public IReadOnlyCollection<T> UpdateRange(IEnumerable<T> entities)
        {
            try
            {
                _context.Set<T>().UpdateRange(entities);
                _context.SaveChanges();

                return entities.ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception in UpdateRange() Method Repository: {ex.Message}");
                throw;
            }
        }

        public void Delete(T entity)
        {
            try
            {
                _context.Set<T>().Remove(entity);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception in Delete() Method Repository: {ex.Message}");
                throw;
            }
        }

        public void DeleteRange(IEnumerable<T> entities)
        {
            try
            {
                _context.Set<T>().RemoveRange(entities);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception in DeleteRange() Method Repository: {ex.Message}");
                throw;
            }
        }
    }    
}