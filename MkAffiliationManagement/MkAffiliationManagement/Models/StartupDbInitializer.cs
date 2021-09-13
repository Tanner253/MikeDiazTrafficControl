using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MkAffiliationManagement.Areas.Identity.Data;
using MkAffiliationManagement.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MkAffiliationManagement.Models
{
    public class StartupDbInitializer
    {
        private static List<ApplicationRoles> Roles = new List<ApplicationRoles>()
        {
            new ApplicationRoles{ Name = ApplicationRoles.ADMIN, NormalizedName = ApplicationRoles.ADMIN.ToUpper() },
            new ApplicationRoles{Name = ApplicationRoles.MEMBER, NormalizedName = ApplicationRoles.ADMIN.ToUpper() }

        };
    public static void SeedData(IServiceProvider servicesProvider, UserManager<ApplicationUser> userManager)
        {
            using (var dbContext = new ApplicationDbContext(servicesProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                dbContext.Database.EnsureCreated();
                

                AddRoles(dbContext);
                SeedUsers(userManager);
            }
        }

        private static void AddRoles(ApplicationDbContext dbContext)
        {
            if (dbContext.Roles.Any())
            {
                return;
            }
            foreach( var role in Roles)
            {
                dbContext.Roles.Add(role);
                dbContext.SaveChangesAsync();
            }
        }
        /// <summary>
        /// seeds a user 
        /// </summary>
        /// <param name="userManager"></param>
        public static void SeedUsers(UserManager<ApplicationUser> userManager)
        {
            if (userManager.FindByNameAsync
                        ("user1").Result == null)
            {
                ApplicationUser user = new ApplicationUser();
                user.UserName = "ADMINMK@gmail.com";
                user.Email = "ADMINMK@gmail.com";
                user.FirstName = "MKADMIN";
                user.LastName = "STAFF";
                

                IdentityResult result = userManager.CreateAsync
                (user, "MkDIAZ32$").Result;

             if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "ADMIN").Wait();
                }
            }


            //    if (userManager.FindByNameAsync
            //("user2").Result == null)
            //    {
            //        ApplicationUser user = new ApplicationUser();
            //        user.UserName = "user2";
            //        user.Email = "user2@localhost";
            //        user.FullName = "Mark Smith";
            //        user.BirthDate = new DateTime(1965, 1, 1);

            //        IdentityResult result = userManager.CreateAsync
            //        (user, "password_goes_here").Result;

            //        if (result.Succeeded)
            //        {
            //            userManager.AddToRoleAsync(user,
            //                                "Administrator").Wait();
            //        }
            //    }
        }
    }
}
