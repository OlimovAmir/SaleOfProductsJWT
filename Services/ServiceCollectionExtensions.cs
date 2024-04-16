using SaleOfProductsJWT.Repositories;
using SaleOfProductsJWT.Services.IService;

namespace SaleOfProductsJWT.Services
{
    public static class ServiceCollectionExtensions
    {
        public static void AddMyServices(this IServiceCollection service)
        {
            service.AddScoped<AuthService>();
            service.AddScoped<IUserService, UserService>();
            service.AddScoped(typeof(IPostgreSQLRepository<>), typeof(PostgreSQLRepository<>));
        }
    }
}
