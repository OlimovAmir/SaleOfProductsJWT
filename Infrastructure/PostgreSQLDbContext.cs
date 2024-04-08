using Microsoft.EntityFrameworkCore;
using SaleOfProductsJWT.Models;

namespace SaleOfProductsJWT.Infrastructure
{
    public class PostgreSQLDbContext :DbContext
    {
        public PostgreSQLDbContext(DbContextOptions<PostgreSQLDbContext> options) : base(options)
        {
            Database.Migrate();
            Database.EnsureCreated();
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Person> Persons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
        }
    }
}
