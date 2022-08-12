namespace Edublock.Models
{
    public class Department : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }

        public int UniversityId { get; set; }
        public University University { get; set; }
        
        public ICollection<Certificate> Certificates { get; set; }
        public ICollection<UserUniversityDepartmentLink> UserUniversityDepartmentLinks { get; set; }
        public ICollection<RequestStatus> RequestStatuses { get; set; }
    }
}
