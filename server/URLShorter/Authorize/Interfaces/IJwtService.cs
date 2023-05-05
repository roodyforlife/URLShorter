using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authorize.Interfaces
{
    public interface IJwtService
    {
        public string CreateToken(IdentityUser user, IList<string> userRoles);
    }
}
