using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BokingWarnet.Utility
{
    public static class SeedData
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            int id = 1;
            var hashed = new PasswordHasher<IdentityUser>();
            modelBuilder.Entity<IdentityUser>().HasData(
                new IdentityUser
                {
                    Id = id.ToString(),
                    UserName = "admin",
                    Email = "admin@gmail.com",
                    NormalizedUserName = "ADMIN",
                    PasswordHash = hashed.HashPassword(null, "admin")
                });
        }
    }
}
