using System.ComponentModel;

namespace Edublock.ViewModels.Department
{
    public class DepartmentBaseViewModel
    {
        [DisplayName("Department Name")]
        public string Name { get; set; } = string.Empty;
        public int UniversityId { get; set; }
        [DisplayName("University")]
        public string UniversityName { get; set; } = string.Empty;
        [DisplayName("Department Description")]
        public string Description { get; set; }
    }
}
