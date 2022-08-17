namespace Edublock.ViewModels.Certificate
{
    public class CertificateCreateViewModel : CertificateBaseViewModel
    {
        public int CertificateTypeId { get; set; }
        public int DepartmentId { get; set; }
        public float Grade { get; set; }
        //public string Owner { get; set; }
        public int WalletId { get; set; }

    }
}
