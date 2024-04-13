using Microsoft.AspNetCore.Identity;
using SaleOfProductsJWT.Models.BaseClassModels;

namespace SaleOfProductsJWT.Models
{
    public class User : BaseEntity
    {
        
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public string Role { get; set; }

        public string? RefreshToken { get; set; }
        public DateTime RefreshTokenExpiryTime { get; set; }

        public User() { }

        public User(Guid id, string name, string email, string password )
        {
            Id = id;
            Name = name;
            Email = email; 
            Password = password;
        }

        public static User Create(Guid id, string name, string email, string password)
        {
            return new User(id, name, email, password);
        }

        public override string ToString()
        {
            return $"{Name} {Email} {Password}";
        }
    }
}
