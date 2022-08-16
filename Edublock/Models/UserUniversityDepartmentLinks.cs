using Edublock.Data;

namespace Edublock.Models
{
    public class UserUniversityDepartmentLink : BaseEntity
    {
        public int UserUniversityLinkId { get; set; }
        public virtual UserUniversityLink UserUniversityLink { get; set; }

        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }

        public string RoleId { get; set; }
        public virtual ApplicationRole Role { get; set; }

    }
}
