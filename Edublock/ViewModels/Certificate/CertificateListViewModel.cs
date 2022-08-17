using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Edublock.ViewModels.Certificate
{
    public class CertificateListViewModel : CertificateBaseViewModel
    {
        public int Id { get; set; }
        [DisplayName("Department")]
        public string DepartmentName { get; set; }
        [DisplayName("University")]
        public string UniversityName { get; set; }
        public string User { get; set; }
    }
}
