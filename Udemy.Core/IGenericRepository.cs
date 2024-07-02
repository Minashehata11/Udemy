using Udemy.Core.Entities;
using Udemy.Core.Specefication;

namespace Udemy.Core
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<T> GetByIdAsync(int Id);
        Task<IReadOnlyList<T>> GetAllWithSpecAsync(ISpecefication<T> spec);
        Task<T> GetByIdWithSpecsAsync(ISpecefication<T> spec);
        Task<int> GetCountWithSpecsAsync(ISpecefication<T> spec);
    }
}
