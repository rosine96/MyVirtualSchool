using Microsoft.AspNetCore.Identity;

namespace VirtualSchool.Models
{
    public class ApplicationUser:IdentityUser

    {
        public string? FirstName { get; set; }
        public string? Name { get; set; }
        public string? Level { get; set;}
        public string? School { get; set; }
        public ICollection<Course>? Courses { get; set; }
    }
}
