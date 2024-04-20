using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SaleOfProductsJWT.Contracts;
using SaleOfProductsJWT.Models;
using SaleOfProductsJWT.Models.UserDTO;
using SaleOfProductsJWT.Services;
using SaleOfProductsJWT.Services.IService;
using SaleOfProductsJWT.Validations;

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


        [HttpPost("CreateUser")]
        public IActionResult CreateUser([FromBody] User user)
        {
            // Проверка валидности данных с помощью FluentValidation
            var validator = new UserValidation();

            // Преобразование User в RequestCreateUser с помощью AutoMapper
            var requestCreateUser = _mapper.Map<RequestCreateUser>(user);

            var validationResult = validator.Validate(requestCreateUser);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            // Сохранение пользователя в базу данных с помощью сервиса
            var result = _service.Create(user);

            // Проверка результата сохранения
            if (result != null)
            {
                return Ok("Пользователь успешно создан");
            }
            else
            {
                return BadRequest("Не удалось создать пользователя");
            }
        }




    }
}
