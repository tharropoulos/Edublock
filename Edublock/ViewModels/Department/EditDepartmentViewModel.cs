namespace Edublock.ViewModels.Department
{
    public class EditDepartmentViewModel
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; } = string.Empty;

        public string? DepartmentDescription { get; set; }

        public int UniversityId { get; set; }
    }
}
