using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Authorize;
using Logic;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DI
{
    public static class DIContainer
    {
        public static void RegisterServices(IServiceCollection services, IConfiguration configuration)
        {
            AuthorizeServicesRegister.RegisterServices(services, configuration);
            LogicServicesRegister.RegisterServices(services, configuration);
        }
    }
}
