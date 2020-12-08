using CrowdControl.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace CrowdControl.Data
{
    public class Seed
    {
        
        public static async Task SeedData(CrowdDBContext context, UserManager<AppUser> userManager)
        {
            if (!userManager.Users.Any())
            {
                var users = new List<AppUser>
                {
                    new AppUser
                    {
                        DisplayName = "Thilina",
                        UserName = "thilina",
                        Email = "thilina@test.com",
                    },

                    new AppUser
                    {
                        DisplayName = "Kavindi",
                        UserName = "kavi",
                        Email = "kavi@test.com",
                    }
                };

                foreach (var user in users)
                {
                    await userManager.CreateAsync(user, "Pa$$w0rd");
                }

                context.SaveChanges();
            }
        }

    }
}

