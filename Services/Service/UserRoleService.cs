﻿using SaleOfProductsJWT.Infrastructure;
using SaleOfProductsJWT.Models;
using SaleOfProductsJWT.Repositories;
using SaleOfProductsJWT.Services.IService;

namespace SaleOfProductsJWT.Services.Service
{
    public class UserRoleService : IUserRoleService
    {
        private readonly IConfiguration _config;
        private readonly PostgreSQLDbContext _context;

        IPostgreSQLRepository<UserRole> _repository;

        public UserRoleService(IPostgreSQLRepository<UserRole> repository, IConfiguration config, PostgreSQLDbContext context)
        {
            _repository = repository;
            _config = config;
            _context = context;
        }

        public string Create(UserRole item)
        {
            if (string.IsNullOrEmpty(item.Name))
            {
                return "The name cannot be empty";
            }
            else
            {
                _repository.Create(item);
                return $"Created new item with this ID: {item.Id}";
            }
        }

        public string Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<UserRole> GetAll()
        {
            throw new NotImplementedException();
        }

        public UserRole GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public string Update(Guid id, UserRole item)
        {
            throw new NotImplementedException();
        }
    }
}