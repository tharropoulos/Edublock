using System.ComponentModel;

namespace Edublock.ViewModels.Department
{
    public class DepartmentListViewModel : DepartmentBaseViewModel
    {
        public int DepartmentId { get; set; }
        [DisplayName("Department Name")]
        public string DepartmentName { get; set; }
        [DisplayName("Department Description")]
        public string Description { get; set; }
        public int UniversityId { get; set; }
        [DisplayName("University")]
        public string UniversityName { get; set; } = string.Empty;
        [DisplayName("Number Of Certificates")]
        public int? NumberOfCertificates { get; set; }
    }
}
