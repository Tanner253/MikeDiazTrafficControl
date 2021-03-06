using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MkAffiliationManagement.Areas.Identity.Data;

namespace MkAffiliationManagement.Data
{
    /* public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
     {
         public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
         {

         }
     }*/
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRoles, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
            builder.Entity<IdentityUserRole<Guid>>().HasKey(p => new { p.UserId, p.RoleId });
        }
    }
}
