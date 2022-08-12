using System.ComponentModel.DataAnnotations;

namespace Edublock.Models
{
    public class Certificate : BaseEntity
    {
        [DataType(DataType.Date)]
        public DateTime CertificateDate { get; set; }
        public float Grade { get; set; }

        public int CertificateTypeId { get; set; }
        public CertificateType CertificateType { get; set; } = default!;

        public int WalletId { get; set; }
        public Wallet Wallet { get; set; } = default!;

        public int DepartmentId { get; set; }
        public Department Department { get; set; } = default!;
    }
}
