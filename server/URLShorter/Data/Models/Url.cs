using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Url
    {
        public int Id { get; set; }
        public IdentityUser User { get; set; }
        public string UserId { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public string Link { get; set; }
        public string NewLink { get; set; }
    }
}
