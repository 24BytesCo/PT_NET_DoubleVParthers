using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace _3.Application.Persistence
{
    public interface IAsyncRepository<T> where T : class
    {
        Task<T> GetEntityAsync(Expression<Func<T, bool>>? predicate, List<Expression<Func<T, object>>>? includes = null, bool disableTracking = true);
        
        Task<IReadOnlyList<T>> GetAllAsync();

        Task<T> GetByIdAsync(int id);

        Task<T> AddAsync(T entity);

        void AddEntity(T entity);


    }
}
