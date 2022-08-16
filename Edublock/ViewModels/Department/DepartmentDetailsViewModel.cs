
using System.ComponentModel;

namespace Edublock.ViewModels.Department
{
    public class DepartmentDetailsViewModel : DepartmentBaseViewModel
    {
        public int Id { get; set; }
        [DisplayName("University")]
        public string UniversityName { get; set; }
        //[DisplayName("Certificates")]
        //public ICollection<CertificateListViewModel> Certificates { get; set; }
    }
}
