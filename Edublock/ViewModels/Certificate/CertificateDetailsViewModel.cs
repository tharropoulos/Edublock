using System.ComponentModel;

namespace Edublock.ViewModels.Certificate
{
    public class CertificateDetailsViewModel : CertificateBaseViewModel
    {
        public int Id { get; set; }
        public float Grade { get; set; }
        public string University { get; set; }
        public string Department { get; set; }
        [DisplayName("Certificate Type")]
        public string CertificateType { get; set; }
        [DisplayName("University Picture")]
        public string UniversityUrl { get; set; }
        public string Owner { get; set; }

    }
}
