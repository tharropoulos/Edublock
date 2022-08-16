using System.ComponentModel;

namespace Edublock.ViewModels.Department
{
    public class DepartmentBaseViewModel
    {
        [DisplayName("Department Name")]
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; }
    }
}
