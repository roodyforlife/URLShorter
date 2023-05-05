using Authorize.Interfaces;
using Authorize.Models;
using Logic.Enums;
using Logic.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace URLShorter
{
    public class Initializer
    {
        static string adminEmail = "admin@gmail.com";
        static string adminPassword = "admin123456";
        public static async Task InitializeAsync(IRoleService roleService, UserManager<IdentityUser> userManager, IAuthorizeService authorize)
        {
            await roleService.Create(Roles.Admin.ToString());
            await roleService.Create(Roles.User.ToString());
            if (await userManager.FindByEmailAsync(adminEmail) is null)
            {
                IdentityUser admin = new IdentityUser { Email = adminEmail, UserName = adminEmail };
                IdentityResult result = await userManager.CreateAsync(admin, adminPassword);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(admin, Roles.Admin.ToString());
                }
            }

        }
    }
}
