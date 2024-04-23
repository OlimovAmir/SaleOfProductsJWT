using SaleOfProductsJWT.Infrastructure;
using SaleOfProductsJWT.Models;
using SaleOfProductsJWT.Repositories;
using SaleOfProductsJWT.Services.IService;

namespace SaleOfProductsJWT.Services.Service
{
    public class UserRoleService : IUserRoleService
    {
        private readonly IConfiguration _config;
        private readonly PostgreSQLDbContext _context;

        IPostgreSQLRepository<UserRole> _repository;
        public string Create(UserRole item)
        {
            throw new NotImplementedException();
        }

        public string Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<UserRole> GetAll()
        {
            throw new NotImplementedException();
        }

        public UserRole GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public string Update(Guid id, UserRole item)
        {
            throw new NotImplementedException();
        }
    }
}
