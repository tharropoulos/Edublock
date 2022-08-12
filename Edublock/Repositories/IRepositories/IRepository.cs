using Edublock.Models;
using System.Linq.Expressions;

namespace Edublock.Repositories.IRepositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<T> GetById(int id);

        Task<List<T>> GetAll();

        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);

        IQueryable<T> GetQuery();

        Task Save();

        Task<bool> Exists(int id);

        IQueryable<T> GetQueryWithPredicate(Expression<Func<T, bool>> predicate);
    }
}
