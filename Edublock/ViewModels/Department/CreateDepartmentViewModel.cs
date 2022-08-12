using Edublock.Models;
namespace Edublock.ViewModels.Department
{
    public class CreateDepartmentViewModel : DepartmentBaseViewModel
    {
        public string DepartmentName { get; set; } = string.Empty;

        public string? DepartmentDescription { get; set; }

        public int UniversityId { get; set; }
    }
}
