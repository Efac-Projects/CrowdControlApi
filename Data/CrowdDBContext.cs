using CrowdControl.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrowdControl.Data
{
    public class CrowdDBContext : IdentityDbContext<AppUser>
    {
        public CrowdDBContext(DbContextOptions<CrowdDBContext> options) : base(options)
        {

        }
        
    }
}
