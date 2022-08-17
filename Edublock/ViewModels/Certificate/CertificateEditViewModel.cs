namespace Edublock.ViewModels.Certificate
{
    public class CertificateEditViewModel : CertificateBaseViewModel
    {
        public int Id { get; set; }
        public float Grade { get; set; }
        public int CertificateTypeId { get; set; }
        public int DepartmentId { get; set; }
        //public int WalletId { get; set; }
    }
}
