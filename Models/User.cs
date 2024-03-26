﻿using SaleOfProductsJWT.Models.BaseClassModels;

namespace SaleOfProductsJWT.Models
{
    public class User : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

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
