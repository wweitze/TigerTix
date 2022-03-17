﻿using Microsoft.EntityFrameworkCore;
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
}
