using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MkAffiliationManagement.Areas.Identity.Data
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public DateTime Birthday { get; set; }


    }

    public class ApplicationRoles : IdentityRole
    {
        public const string Member = "Member";
        public const string Admin = "Admin";
    }
}
