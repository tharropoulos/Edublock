namespace Edublock.Models
{
    public class CertificateType : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; }

        public virtual ICollection<Certificate> Certificates { get; set; }
    }
}
