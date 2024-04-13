using SaleOfProductsJWT.Models;

namespace SaleOfProductsJWT.Services.IService
{
    public interface IUserService : IBaseService<User>
    {
        User Authenticate(string username, string password);
    }
}
