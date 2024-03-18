using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace VirtualSchool.Models
{
    public class RoleAssign
    {
        public IEnumerable<ApplicationUser>? Users { get; set; }
        public IEnumerable<IdentityRole>? Roles { get; set; }
    }
}
