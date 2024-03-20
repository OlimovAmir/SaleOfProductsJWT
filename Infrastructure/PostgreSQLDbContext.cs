using Microsoft.EntityFrameworkCore;

namespace SaleOfProductsJWT.Infrastructure
{
    public class PostgreSQLDbContext :DbContext
    {
        public PostgreSQLDbContext(DbContextOptions<PostgreSQLDbContext> options) : base(options)
        {
            Database.Migrate();
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
