using SaleOfProductsJWT.Models;

namespace SaleOfProductsJWT.Services
{
    public interface IUserService: IBaseService<User>
    {
        User Authenticate(string username, string password);
    }
}
