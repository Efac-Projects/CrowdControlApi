using CrowdControl.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrowdControl.Data
{
    public class CrowdDBContext : IdenityDbContext
    {
        public CrowdDBContext(DbContextOptions<CrowdDBContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; } // user table
    }
}
