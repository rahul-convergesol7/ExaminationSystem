using ES.Domain.Entity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Domain.AdminSeed
{
    public static class SeedData
    {
        public static async Task Initialize(UserManager<ApplicationUser> userManager,RoleManager<ApplicationRole> roleManager)
        {
            await SeedRole(roleManager);
            await SeedUser(userManager);
        }

        private static async Task SeedUser(UserManager<ApplicationUser> userManager)
        {
            var adminEmail = "admin@gmail.com";
            var adminPassword = "Admin@123";
            var adminUser = await userManager.FindByEmailAsync(adminEmail);
            if (adminUser == null)
            {
                adminUser = new ApplicationUser
                {
                    UserName = adminEmail,
                    Email = adminEmail
                };

                await userManager.CreateAsync(adminUser, adminPassword);
                await userManager.AddToRoleAsync(adminUser, "Admin");
            }

        }
        private static async Task SeedRole(RoleManager<ApplicationRole> roleManager)
        {
            string[] userRoles = { "Admin", "User" };


            foreach(var roleName in userRoles)
            {
                var existRole = await roleManager.RoleExistsAsync(roleName);

                if (!existRole)
                {
                    await roleManager.CreateAsync(new ApplicationRole { Name=roleName});
                }
            }


        }
    }
}
