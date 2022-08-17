using System.ComponentModel.DataAnnotations;

namespace Edublock.Models
{
    public class Certificate : BaseEntity
    {
        [DataType(DataType.Date)]
        public DateTime CertificateDate { get; set; }
        public float Grade { get; set; }

        public int CertificateTypeId { get; set; }
        public virtual CertificateType CertificateType { get; set; } = default!;

        public int WalletId { get; set; }
        public virtual Wallet Wallet { get; set; } = default!;

        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; } = default!;

        public int? RequestId { get; set; }
        public virtual Request Request { get; set; }
    }
}
