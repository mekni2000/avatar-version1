using AspAdminTemplate.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspAdminTemplate.Data
{
	public class DbContextSeedData
	{
        public void SeedData(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager)
        {
            if (!roleManager.RoleExistsAsync("Admin").Result)
            {
                ApplicationRole role = new ApplicationRole
                {
                    Name = "Admin",
                    NormalizedName = "Admin"
                };
                roleManager.CreateAsync(role).Wait();
            }

            if (userManager.FindByNameAsync("Admin").Result == null)
            {

                var user = new ApplicationUser
                {
                    UserName = "Admin",
                    NormalizedUserName = "admin",
                    Email = "Admin@admin.com",
                    NormalizedEmail = "admin@admin.com",
                    EmailConfirmed = true,
                    LockoutEnabled = false,
                    SecurityStamp = Guid.NewGuid().ToString()
                };

                var password = new PasswordHasher<ApplicationUser>();
                var hashed = password.HashPassword(user, "Admin@123");
                user.PasswordHash = hashed;

                IdentityResult result = userManager.CreateAsync(user).Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Admin").Wait();
                }
            }
        }
	}
}
