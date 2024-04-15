﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SaleOfProductsJWT.Models;
using SaleOfProductsJWT.Services.IService;

namespace SaleOfProductsJWT.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class UserController : BaseController<User>
    {
       
        public UserController(ILogger<UserController> logger, IUserService service) : base(logger, service)
        {
        }
            

    }
}
