using _2.Infraestructure.Persistence;
using _3.Application.Persistence;
using System.Collections;


namespace _2.Infraestructure.Repositories
{

    public class UnitOfWork : IUnitOfWork
    {
        private Hashtable? _repositories;

        private readonly DbContext _context;

        public UnitOfWork(DbContext context)
        {
            _context = context;
        }


        public async Task<int> Complete()
        {

            try
            {
                return await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception("Error en transacion", e);
            }

        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public IAsyncRepository<TEntity> Repository<TEntity>() where TEntity : class
        {
            if (_repositories is null)
            {
                _repositories = new Hashtable();
            }

            var type = typeof(TEntity).Name;

            if (!_repositories.ContainsKey(type))
            {
                var repositoryType = typeof(RepositoryBase<>);
                var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), _context);
                _repositories.Add(type, repositoryInstance);
            }

            return (IAsyncRepository<TEntity>)_repositories[type]!;


        }
    }
}