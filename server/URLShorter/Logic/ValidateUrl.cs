using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    internal static class ValidateUrl
    {
        internal static bool IsValidUri(string urlString)
        {
            try
            {
                new Uri(urlString);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
