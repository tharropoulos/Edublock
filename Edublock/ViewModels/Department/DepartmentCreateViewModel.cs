using Edublock.Models;
namespace Edublock.ViewModels.Department
{
    public class DepartmentCreateViewModel : DepartmentBaseViewModel
    {
        [DisplayName("University")]
        public int UniversityId { get; set; }
    }
}
