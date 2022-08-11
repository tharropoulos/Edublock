using Edublock.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Edublock.ViewModels.Certificate
{
    public class CreateCertificateViewModel
    {
        [DisplayName("Type of Certificate")]
        public int TypeOfCertificateId { get; set; }
        [DisplayName("Owner")]
        public int UserId { get; set; }
        [DisplayName("Department")]
        public int DepartmentId { get; set; }
        public DateOnly CertificateDate { get; set; }
        public float Grade { get; set; }
    }
}
