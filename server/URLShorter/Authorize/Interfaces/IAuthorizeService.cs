using Authorize.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authorize.Interfaces
{
    public interface IAuthorizeService
    {
        public Task<AuthorizeResponse> LoginAsync(Login model);
        public Task<AuthorizeResponse> RegistAsync(Register model);
    }
}
