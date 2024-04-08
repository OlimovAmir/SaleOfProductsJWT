using SaleOfProductsJWT.Models.BaseClassModels;

namespace SaleOfProductsJWT.Models
{
    public class Person : BaseEntity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }

        public string FullName => $"{FirstName} {LastName}";

        public string Username { get; set; }

        public string Password { get; set; }

        public string RefreshToken { get; set; }

        public string Role { get; set; }

        public DateTimeOffset Birthday { get; set; }

        public bool IsBlocked { get; }
    }
}
