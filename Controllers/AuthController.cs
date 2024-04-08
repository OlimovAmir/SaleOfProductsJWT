using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SaleOfProductsJWT.Models;
using SaleOfProductsJWT.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SaleOfProductsJWT.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly IUserService _userService;

        public AuthController(IConfiguration config, IUserService userService)
        {
            _config = config;
            _userService = userService;
        }

        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] AuthenticateRequest model)
        {
            var user = _userService.Authenticate(model.Username, model.Password);

            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            // Генерация JWT токена
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_config["Jwt:Secret"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                new Claim(ClaimTypes.Name, user.Id.ToString()),
                new Claim(ClaimTypes.Role, user.Role)
                }),
                Expires = DateTime.UtcNow.AddHours(1), // Токен истекает через 1 час
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            // Возвращаем результат аутентификации с токеном
            return Ok(new
            {
                user.Id,
                user.Name,
                user.Role,
                Token = tokenString // Добавляем токен к результату аутентификации
            });
        }
    }
}
