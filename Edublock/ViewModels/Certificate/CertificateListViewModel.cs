using System.ComponentModel.DataAnnotations;

namespace Edublock.ViewModels.Certificate
{
    public class CertificateListViewModel : CertificateBaseViewModel
    { 
        public int Id { get; set; }
        public int DepartmentId { get; set; }
        public string UniversityThumbnailUrl { get; set; }
    }
}
