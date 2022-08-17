namespace Edublock.ViewModels.Certificate
{
    public class CertificateCreateViewModel : CertificateBaseViewModel
    {
        public int CertificateTypeId { get; set; }
        public int DepartmentId { get; set; }
        public int WalletId { get; set; }
        public float Grade { get; set; }
    }
}
