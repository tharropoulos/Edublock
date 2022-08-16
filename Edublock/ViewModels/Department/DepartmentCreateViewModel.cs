using Edublock.Models;
using System.ComponentModel;

namespace Edublock.ViewModels.Department
{
    public class DepartmentCreateViewModel : DepartmentBaseViewModel
    {
        [DisplayName("University")]
        public int UniversityId { get; set; }
    }
}
