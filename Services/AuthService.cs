using Microsoft.AspNetCore.Authentication;
using SaleOfProductsJWT.Contracts;
using SaleOfProductsJWT.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using SaleOfProductsJWT.Auth;
using SaleOfProductsJWT.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;


namespace SaleOfProductsJWT.Services
{
    public class AuthService
    {
        private readonly PostgreSQLDbContext _context;
        public AuthService(PostgreSQLDbContext context)
        {
            _context = context;
        }

        public async Task<TokenInfo> Login(string username, string password)
        {
            var user = await _context.Persons.SingleOrDefaultAsync(x => x.Username == username && x.Password == password);

            return await GeneratedJWT(user);
        }

        public async Task<TokenInfo> RefreshToken(string refreshToken)
        {
            var user = await _context.Persons.SingleOrDefaultAsync(x => x.RefreshToken == refreshToken);

            return await GeneratedJWT(user);
        }

        async Task<TokenInfo> GeneratedJWT(Person user)
        {
            if (user is null)
                throw new ArgumentException("Invalid username or password.");

            if (user.IsBlocked)
                throw new ArgumentException("User does not have access to login.");

            var claims = new List<Claim> {
                new Claim("Id", user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.FullName),
                new Claim(ClaimTypes.Role, user.Role)
            };

            // создаем JWT-токен
            var jwt = new JwtSecurityToken(
                    issuer: AuthOptions.ISSUER,
                    audience: AuthOptions.AUDIENCE,
                    claims: claims,
                    expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
                    signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));

            var accessToken = new JwtSecurityTokenHandler().WriteToken(jwt);
            var refreshToken = Guid.NewGuid().ToString();

            user.RefreshToken = refreshToken;
            await _context.SaveChangesAsync();

            return new TokenInfo { AccessToken = accessToken, RefreshToken = refreshToken };
        }

    }
}
