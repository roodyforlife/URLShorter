using Logic.Interfaces;
using Logic.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public static class LogicServicesRegister
    {
        public static void RegisterServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IUrlService, UrlService>();
            services.AddScoped<IUserService, UserService>();
        }
    }
}
