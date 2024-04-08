using Microsoft.AspNetCore.Authentication;
using SaleOfProductsJWT.Contracts;
using SaleOfProductsJWT.Infrastructure;

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

    }
}
