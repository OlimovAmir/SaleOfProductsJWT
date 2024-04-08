﻿using Microsoft.EntityFrameworkCore;
using SaleOfProductsJWT.Models;
using SaleOfProductsJWT.Models.BaseClassModels;

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
            modelBuilder.Ignore<BaseEntity>();

            modelBuilder.Entity<Person>(entity =>
            {
                entity.HasKey(p => p.Id);
                entity.HasIndex(p => p.Username).IsUnique();
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
