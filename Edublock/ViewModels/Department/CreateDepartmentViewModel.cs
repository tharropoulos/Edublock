using Edublock.Models;
namespace Edublock.ViewModels
{
    public class CreateDepartmentViewModel
    {
        public string DepartmentName { get; set; } = string.Empty;

        public string? DepartmentDescription { get; set; }

        public int UniversityId { get; set; }
    }
}
