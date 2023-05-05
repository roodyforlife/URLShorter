using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authorize.Models
{
    public class AuthorizeResponse
    {
        public bool Success { get; set; }
        public string Token { get; set; }
        public List<string> Errors { get; set; } = new();
        public AuthorizeResponse(bool success, string token)
        {
            Success = success;
            Token = token;
        }

        public AuthorizeResponse(bool success)
        {
            Success = success;
        }

        public void AddError(string error)
        {
            Errors.Add(error);
        }
    }
}
