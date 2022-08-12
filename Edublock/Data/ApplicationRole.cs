using Edublock.Enumerations;
using Edublock.Models;
using Microsoft.AspNetCore.Identity;

namespace Edublock.Data
{
    public class ApplicationRole : IdentityRole
    {
        public UserType UserType { get; set; }
        public ICollection<UserUniversityDepartmentLink> UserUniversityDepartmentLinks { get; set; }
    }
}
