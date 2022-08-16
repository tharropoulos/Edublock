using Edublock.Data;

namespace Edublock.Models
{
    public class UserUniversityLink : BaseEntity
    {
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }

        public int UniversityId { get; set; }
        public virtual University University { get; set; }

        public virtual ICollection<UserUniversityDepartmentLink> UserUniversityDepartmentLinks { get; set; }
    }
}
