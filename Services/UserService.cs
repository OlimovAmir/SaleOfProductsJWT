using SaleOfProductsJWT.Models;
using SaleOfProductsJWT.Repositories;

namespace SaleOfProductsJWT.Services
{
    public class UserService : IUserService
    {
        IPostgreSQLRepository<User> _repository;

        public UserService(IPostgreSQLRepository<User> repository)
        {
            _repository = repository;
        }
        public string Create(User item)
        {
            throw new NotImplementedException();
        }

        public string Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public User GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public string Update(Guid id, User item)
        {
            throw new NotImplementedException();
        }
    }
}
