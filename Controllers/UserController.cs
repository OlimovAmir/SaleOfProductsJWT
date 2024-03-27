using Microsoft.AspNetCore.Mvc;
using SaleOfProductsJWT.Models;
using SaleOfProductsJWT.Services;

namespace SaleOfProductsJWT.Controllers
{
    public class UserController : BaseController<User>
    {
        public UserController(ILogger<UserController> logger, IUserService service) : base(logger, service)
        {
        }
    }
}
