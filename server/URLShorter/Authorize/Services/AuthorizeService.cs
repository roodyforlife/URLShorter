using Authorize.Interfaces;
using Authorize.Models;
using Logic.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authorize.Services
{
    class AuthorizeService : IAuthorizeService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IJwtService _jwtService;
        public AuthorizeService(UserManager<IdentityUser> userManager, IJwtService jwtService, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _jwtService = jwtService;
            _signInManager = signInManager;
        }

        public async Task<AuthorizeResponse> LoginAsync(Login model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user is null || !await CheckPassword(user, model.Password))
            {
                var response = new AuthorizeResponse(false);
                response.AddError("Login or password is incorrect");
                return response;
            }

            var userRoles = await _userManager.GetRolesAsync(user);

            return new AuthorizeResponse(true, _jwtService.CreateToken(user, userRoles));
        }

        public async Task<AuthorizeResponse> RegistAsync(Register model)
        {
            var response = new AuthorizeResponse(false);
            if (_userManager.Users.FirstOrDefault(x => x.Email == model.Email) is not null)
            {
                response.AddError("Email has been taken");
                return response;
            }

            IdentityUser user = new IdentityUser() { Email = model.Email, UserName = model.Name };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, Roles.User.ToString());

                var userRoles = await _userManager.GetRolesAsync(user);
                return new AuthorizeResponse(true, _jwtService.CreateToken(user, userRoles));
            }

            foreach (var error in result.Errors)
            {
                response.AddError(error.Description);
            }

            return response;
        }

        private async Task<bool> CheckPassword(IdentityUser user, string password)
        {
            return (await _signInManager.CheckPasswordSignInAsync(user, password, false)).Succeeded;
        }
    }
}
