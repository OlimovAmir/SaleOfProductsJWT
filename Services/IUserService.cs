using SaleOfProductsJWT.Models;
using SaleOfProductsJWT.Services.IService;

namespace SaleOfProductsJWT.Services
{
    public interface IUserService: IBaseService<User>
    {
        User Authenticate(string username, string password);
    }
}
