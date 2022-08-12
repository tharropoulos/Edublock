
using System.ComponentModel;

namespace Edublock.ViewModels
{
    public class DepartmentDetailsViewModel : DepartmentBaseViewModel
    {
        public int DepartmentId { get; set; }

        [DisplayName("Certificates")]
        public ICollection<CertificateListViewModel> Certificates { get; set; }
    }
}
