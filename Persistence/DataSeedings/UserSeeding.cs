using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.DataSeedings
{
    public static class UserSeeding
    {
        public static ModelBuilder SeedUsers(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>().HasData(
               new Admin { Id = "da18f5d6-6034-436c-9393-1787b8b419fb", Email = "Admin@Admin.com", PasswordHash = BCrypt.Net.BCrypt.HashPassword("P@ssw0rd2024") });
            return modelBuilder;
        }
    }
}
