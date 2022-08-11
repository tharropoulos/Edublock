using System.ComponentModel.DataAnnotations;

namespace Edublock.Models
{
    public class Certificate
    {
        public int CertificateId { get; set; }
        public int TypeOfCertificateId { get; set; }
        public TypeOfCertificate TypeOfCertificate { get; set; } = default!;

        public int WalletId { get; set; }
        public Wallet Wallet { get; set; } = default!;
        public int DepartmentId { get; set; }
        public Department Department { get; set; } = default!;
        //public int UniversityId { get; set; }
        //public University University { get; set; } = default!;

        [DataType(DataType.Date)]
        public DateTime CertificateDate { get; set; }

        public float Grade { get; set; }
    }
}
