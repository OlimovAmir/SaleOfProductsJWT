using Microsoft.IdentityModel.Tokens;
using SaleOfProductsJWT.Infrastructure;
using SaleOfProductsJWT.Models;
using SaleOfProductsJWT.Repositories;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SaleOfProductsJWT.Services
{
    public class UserService : IUserService
    {
        private readonly IConfiguration _config;
        private readonly PostgreSQLDbContext _context;

        IPostgreSQLRepository<User> _repository;

        public UserService(IPostgreSQLRepository<User> repository, IConfiguration config, PostgreSQLDbContext context)
        {
            _repository = repository;
            _config = config;
            _context = context;
        }



        public User Authenticate(string username, string password)
        {
            var user = _context.Users.SingleOrDefault(x => x.Name == username && x.Password == password);

            // Return null if user not found
            if (user == null)
                return null;

            // Authentication successful so generate JWT token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_config["Jwt:Secret"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                new Claim(ClaimTypes.Name, user.Id.ToString()),
                new Claim(ClaimTypes.Role, user.Role)
                }),
                Expires = DateTime.UtcNow.AddHours(1), // Token expires in 1 hour
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            

            // Remove password before returning
            user.Password = null;

            return user;
        }

        public string Create(User item)
        {
            if (string.IsNullOrEmpty(item.Name))
            {
                return "The name cannot be empty";
            }
            else
            {
                _repository.Create(item);
                return $"Created new item with this ID: {item.Id}";
            }
        }

        public string Delete(Guid id)
        {
            var result = _repository.Delete(id);
            if (result)
                return "Item deleted";
            else
                return "Item not found";
        }

        public IQueryable<User> GetAll()
        {
            return _repository.GetAll();
        }

        public User GetById(Guid id)
        {
            return _repository.GetById(id);
        }

        public string Update(Guid id, User item)
        {
            var _item = _repository.GetById(id);
            if (_item is not null)
            {
                _item.Name = item.Name;
                _item.Email = item.Email;
                _item.Password = item.Password;
                

                var result = _repository.Update(_item);
                if (result)
                    return "Item updated";
            }

            return "Item updated";
        }
    }
}
