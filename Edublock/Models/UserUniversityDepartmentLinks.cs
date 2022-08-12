using Edublock.Data;

namespace Edublock.Models
{
    public class UserUniversityDepartmentLink : BaseEntity
    {
        public int UserUniversityLinkId { get; set; }
        public UserUniversityLink UserUniversityLink { get; set; }

        public int DepartmentId { get; set; }
        public Department Department { get; set; }

        public string RoleId { get; set; }
        public ApplicationRole Role { get; set; }

    }
}
