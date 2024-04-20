using Microsoft.AspNetCore.Identity;
using SaleOfProductsJWT.Models.BaseClassModels;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;


namespace SaleOfProductsJWT.Models
{
    public class User : BaseEntity
    {
        [JsonIgnore]
        public override Guid Id { get; set; }
        [Required(ErrorMessage = "Имя пользователя обязательно для заполнения")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Email обязателен для заполнения")]
        [EmailAddress(ErrorMessage = "Введите корректный Email")]
        public string Email { get; set; }
        public string Password { get; set; }

        public string Role { get; set; }

        [JsonIgnore]
        public string? RefreshToken { get; set; }
        [JsonIgnore]
        public DateTime RefreshTokenExpiryTime { get; set; }

        public bool IsBlocked { get; }

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
