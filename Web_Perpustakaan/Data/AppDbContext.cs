using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_Perpustakaan.Models;

namespace Web_Perpustakaan.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public virtual DbSet<Roles> Tb_Roles { get; set; }
        public virtual DbSet<User> Tb_User { get; set; }
    }
}
