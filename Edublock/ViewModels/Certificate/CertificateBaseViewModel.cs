using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Edublock.ViewModels.Certificate
{
    public class CertificateBaseViewModel
    {
        [DataType(DataType.Date)]
        public DateTime CertificateDate { get; set; }

        //public string CertificateDateStr
        //{
        //    get
        //    {
        //        return CertificateDate.ToString("dd/MM/yyyy");
        //    }
        //}




    }
}
