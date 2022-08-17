namespace Edublock.Models
{
    public class Department : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; }

        public int UniversityId { get; set; }
        public virtual University University { get; set; }
        
        public virtual ICollection<Certificate> Certificates { get; set; }
        public virtual ICollection<UserUniversityDepartmentLink> UserUniversityDepartmentLinks { get; set; }
        public virtual ICollection<RequestStatus> RequestStatuses { get; set; }
        public virtual ICollection<Request> Requests { get; set; }

    }
}
