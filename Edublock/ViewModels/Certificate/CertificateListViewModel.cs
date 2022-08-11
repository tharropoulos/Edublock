using System.ComponentModel.DataAnnotations;

namespace Edublock.ViewModels
{
    public class CertificateListViewModel
    {
        public string DepartmentName { get; set; } = string.Empty;
        public int DepartmentId { get; set; }
        public string? UniversityThumbnailUrl { get; set; }
        public string CertificateType { get; set; } = string.Empty;
        public int CertificateId { get; set; }

        [DataType(DataType.Date)]
        public DateTime CertificateDate { get; set; }

        public string CertificateDateStr
        {
            get
            {
                return CertificateDate.ToString("dd/MM/yyyy");
            }
        }
    }
}
