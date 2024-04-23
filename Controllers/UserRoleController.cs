using Microsoft.AspNetCore.Mvc;

namespace SaleOfProductsJWT.Controllers
{
    public class UserRoleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
