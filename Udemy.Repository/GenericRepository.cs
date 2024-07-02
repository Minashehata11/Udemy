using Microsoft.EntityFrameworkCore;
using Udemy.Core;
using Udemy.Core.Entities;
using Udemy.Core.Specefication;
using Udemy.Repository.Data;

namespace Udemy.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly UdemyDbContext _udemyDbContext;

        public GenericRepository(UdemyDbContext udemyDbContext)
        {
            _udemyDbContext = udemyDbContext;
        }

        public  void Add(T entity)
         => _udemyDbContext.Add(entity);

        public void Delete(T entity)
        => _udemyDbContext.Remove(entity);

       
        public void Update(T entity)
        => _udemyDbContext.Update(entity);

        public async Task<IReadOnlyList<T>> GetAllAsync()
        => await _udemyDbContext.Set<T>().ToListAsync();

        public async Task<T> GetByIdAsync(int Id)
        => await _udemyDbContext.Set<T>().FindAsync(Id);

        public async Task<IReadOnlyList<T>> GetAllWithSpecAsync(ISpecefication<T> spec)
           => await ApplySpecification(spec).ToListAsync();


        public async Task<T> GetByIdWithSpecsAsync(ISpecefication<T> spec)
        => await ApplySpecification(spec).FirstOrDefaultAsync();

        public async Task<int> GetCountWithSpecsAsync(ISpecefication<T> spec)
         => await ApplySpecification(spec).CountAsync();

        private IQueryable<T> ApplySpecification(ISpecefication<T> spec)
            => SpecificationEvaluator<T>.GetQuery(_udemyDbContext.Set<T>(), spec);
    }
}
