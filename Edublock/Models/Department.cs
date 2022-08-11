namespace Edublock.Models
{
    public class Department
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; } = string.Empty;

        public string? DepartmentDescription { get; set; }

        public int UniversityId { get; set; }
        public University University { get; set; }

        public ICollection<Certificate>? Certificates { get; set; }
    }
}
