using App.Domain.Core.Member.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.DB.SqlServer.EF.EntitiesConfigoration
{
    public class UserConfiguration
    {
        public static void SeedUsers(ModelBuilder builder)
        {
            var hasher = new PasswordHasher<ApplicationUser>();
            #region seedUsers
            var users = new List<ApplicationUser>()
            {
                new ApplicationUser()
                {
                    Id = 1,
                    UserName = "admin",
                    NormalizedUserName = "ADMIN",
                    Email = "admin@gmail.com",
                    NormalizedEmail = "ADMIN@GMAIL.COM",
                    
                    LockoutEnabled = false,
                    PhoneNumber ="09179197331",
                    SecurityStamp = Guid.NewGuid().ToString()
                },
                new ApplicationUser()
                {
                    Id = 2,
                    UserName = "mohammad",
                    NormalizedUserName = "MOHAMMAD",
                    Email = "mohammad@gmail.com",
                    NormalizedEmail = "MOHAMMAD@GMAIL.COM",
                    LockoutEnabled = false,
                    PhoneNumber ="09179197331",
                    SecurityStamp = Guid.NewGuid().ToString()
                },new ApplicationUser()
                {
                    Id = 3,
                    UserName = "expert",
                    NormalizedUserName = "EXPERT",
                    Email = "expert@gmail.com",
                    NormalizedEmail = "EXPERT@GMAIL.COM",
                    LockoutEnabled = false,
                    PhoneNumber ="09179197331",
                    SecurityStamp = Guid.NewGuid().ToString()
                },
                new ApplicationUser()
                {
                    Id = 4,
                    UserName = "negin",
                    NormalizedUserName = "NEGIN",
                    Email = "negin@gmail.com",
                    NormalizedEmail = "NEGIN@GMAIL.COM",
                    LockoutEnabled = false,
                    PhoneNumber ="09179197331",
                    SecurityStamp = Guid.NewGuid().ToString()
                },
                new ApplicationUser()
                {
                    Id = 5,
                    UserName = "ahmad",
                    NormalizedUserName = "AHMAD",
                    Email = "ahmad@gmail.com",
                    NormalizedEmail = "AHMAD@GMAIL.COM",
                    LockoutEnabled = false,
                    PhoneNumber ="09179197331",
                    SecurityStamp = Guid.NewGuid().ToString()
                }
            };
            #endregion
            #region password
            foreach (var user in users)
            {
                var passwordHasher = new PasswordHasher<ApplicationUser>();
                user.PasswordHash = passwordHasher.HashPassword(user, "123456789");

                builder.Entity<ApplicationUser>().HasData(user);
            }
            #endregion
            #region seedRoles
            builder.Entity<IdentityRole<int>>()
                .HasData(
            new IdentityRole<int>() { Id = 1, Name = "Admin", NormalizedName = "ADMIN" },
            new IdentityRole<int>() { Id = 2, Name = "Customer", NormalizedName = "CUSTOMER" },
            new IdentityRole<int>() { Id = 3, Name = "expert", NormalizedName = "EXPERT" }
                );
            #endregion
            #region seed Role To user
            builder.Entity<IdentityUserRole<int>>().HasData(
            new IdentityUserRole<int>() { RoleId = 1, UserId = 1 },
            new IdentityUserRole<int>() { RoleId = 2, UserId = 2 },
            new IdentityUserRole<int>() { RoleId = 3, UserId = 3 },
            new IdentityUserRole<int>() { RoleId = 2, UserId = 4 },
            new IdentityUserRole<int>() { RoleId = 3, UserId = 5 }
            );
            #endregion
        }
    }
}
