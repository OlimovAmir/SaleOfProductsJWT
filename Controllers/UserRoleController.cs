using Microsoft.AspNetCore.Mvc;
using SaleOfProductsJWT.Models;
using SaleOfProductsJWT.Controllers;
using AutoMapper;
using SaleOfProductsJWT.Services.IService;

namespace SaleOfProductsJWT.Controllers
{
    public class UserRoleController : BaseController<UserRole>
    {
        private readonly IMapper _mapper;
        public UserRoleController(ILogger<UserRoleController> logger, IUserRoleService service, IMapper mapper) : base(logger, service)
        {
            _mapper = mapper;
        }
    }
}
