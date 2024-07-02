using System.Collections;
using Udemy.Core;
using Udemy.Core.Entities;
using Udemy.Repository.Data;

namespace Udemy.Repository
{
    public class UnitOfWork : IUnitOfWork 
    {
        private readonly UdemyDbContext _udemyDbContext;
        private Hashtable _respositories;
        public UnitOfWork(UdemyDbContext udemyDbContext)
        {
            _udemyDbContext = udemyDbContext;
            _respositories = new Hashtable();
        }
       
        public async Task<int> CompleteAsync()
        => await _udemyDbContext.SaveChangesAsync();

      
        public async ValueTask DisposeAsync()
        => await _udemyDbContext.DisposeAsync();

        public IGenericRepository<Tentity> Repository<Tentity>() where Tentity : BaseEntity
        {
            var type = typeof(Tentity).Name; //product //address
            if (!_respositories.ContainsKey(type))
            {
                var Repository = new GenericRepository<Tentity>(_udemyDbContext);
                _respositories.Add(type, Repository);
            }
            return (IGenericRepository<Tentity>)_respositories[type];
        }

      
    }
}
