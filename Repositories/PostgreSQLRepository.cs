
using SaleOfProductsJWT.Infrastructure;
using SaleOfProductsJWT.Models.BaseClassModels;

namespace SaleOfProductsJWT.Repositories
{
    public class PostgreSQLRepository<T> : IPostgreSQLRepository<T> where T : BaseEntity
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
            try
            {
                var item = _context.Set<T>().SingleOrDefault(w => w.Id == id);
                if (item is not null)
                {
                    _context.Remove(item);
                    var result = _context.SaveChanges();
                    return result > 0;
                }
            }
            catch
            { }

            return false;
        }

        public IQueryable<T> GetAll()
        {
            return _context.Set<T>();
        }

        public T GetById(Guid id)
        {
            return _context.Set<T>().SingleOrDefault(w => w.Id == id);
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
