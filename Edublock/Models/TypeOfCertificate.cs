namespace Edublock.Models
{
    public class TypeOfCertificate
    {
        public int TypeOfCertificateId { get; set; }
        public string TypeOfCertificateName { get; set; } = string.Empty;

        public string? TypeOfCertificateDescription { get; set; }

        public ICollection<Certificate>? Certificates { get; set; }
    }
}
