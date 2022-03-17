using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TigerTix.Data.Entities;

namespace TigerTix.Data
{
    public class TigerTixContext : DbContext
    {
        public DbSet<User> Users { get; set; }
    }

    private readonly IConfiguration _config;

    public TigerTixContext (IConfiguration config)
    {
        _config = config;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseSqlServer(_config["ConnectionStrings:DefaultConnection"])''
    }
}
