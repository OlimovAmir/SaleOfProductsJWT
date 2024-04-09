
using SaleOfProductsJWT.Infrastructure;

namespace SaleOfProductsJWT.Repositories
{
    public class PostgreSQLRepository<T> : IPostgreSQLRepository<T>
    {
        readonly PostgreSQLDbContext _context;
        public PostgreSQLRepository(PostgreSQLDbContext bankContext)
        {
            _context = bankContext;
        }
        public bool Create(T item)
        {
            try
            {
                _context.Add(item);
                var result = _context.SaveChanges();
                return result > 0;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> GetAll()
        {
            return _repository.GetAll();
        }

        public T GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public bool Update(T item)
        {
            try
            {
                _context.Update(item);
                var result = _context.SaveChanges();
                return result > 0;
            }
            catch
            {
                return false;
            }
        }
    }
}
