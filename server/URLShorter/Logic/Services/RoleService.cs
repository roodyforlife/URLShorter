using Logic.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Services
{
    class RoleService : IRoleService
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public RoleService(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task Create(string name)
        {
            if (await _roleManager.FindByNameAsync(name) == null)
            {
                await _roleManager.CreateAsync(new IdentityRole(name));
            }
        }
    }
}
