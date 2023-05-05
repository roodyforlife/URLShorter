using Logic.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Services
{
    class UserService : IUserService
    {
        private readonly UserManager<IdentityUser> _userManager;
        public UserService(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public IdentityUser Get(string userName)
        {
            return _userManager.Users.FirstOrDefault(x => x.Email == userName);
        }
    }
}
