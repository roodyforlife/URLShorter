using Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class DataBaseContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<Url> Urls { get; set; }
        public DataBaseContext(DbContextOptions<DataBaseContext> options)
               : base(options)
        {
            // Database.EnsureDeleted();
            Database.EnsureCreated();
        }
    }
}
