using Microsoft.AspNetCore.Authentication;
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

    }
}
