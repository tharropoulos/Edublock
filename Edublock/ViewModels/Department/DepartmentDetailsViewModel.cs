
using System.ComponentModel;

namespace Edublock.ViewModels
{
    public class DepartmentDetailsViewModel
    {
        public int DepartmentId { get; set; }
        [DisplayName("Department Name")]
        public string DepartmentName { get; set; } = string.Empty;
        [DisplayName("Department Description")]
        public int UniversityId { get; set; }
        [DisplayName("University")]
        public string UniversityName { get; set; } = string.Empty;
        public string DepartmentDescription { get; set; }
        [DisplayName("Certificates")]
        public ICollection<CertificateListViewModel> Certificates { get; set; }
    }
}
