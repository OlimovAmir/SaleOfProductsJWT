using Microsoft.AspNetCore.Mvc;

namespace SaleOfProductsJWT.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
