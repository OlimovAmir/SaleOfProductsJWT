using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SaleOfProductsJWT.Models;
using SaleOfProductsJWT.Models.UserDTO;
using SaleOfProductsJWT.Services;
using SaleOfProductsJWT.Services.IService;

namespace SaleOfProductsJWT.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class UserController : BaseController<User>
        
    {
        private readonly IMapper _mapper;
        public UserController(ILogger<UserController> logger, IUserService service, IMapper mapper) : base(logger, service)
        {
            _mapper = mapper;
        }

       
        [HttpGet("AllUSER")]
        public virtual IEnumerable<UserDTO> Get()
        {
            var users = _service.GetAll();
            var userDTOs = _mapper.Map<IEnumerable<UserDTO>>(users);
            return userDTOs;
        }

       



    }
}
