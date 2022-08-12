using Edublock.Data;

namespace Edublock.Models
{
    public class UserUniversityLink : BaseEntity
    {
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        public int UniversityId { get; set; }
        public University University { get; set; }

        public ICollection<UserUniversityDepartmentLink> UserUniversityDepartmentLinks { get; set; }
    }
}
