using Edublock.Models;
namespace Edublock.ViewModels.Request
{
    public class RequestCreateViewModel :RequestBaseViewModel
    {
        public string UserId { get; set; }
        public int DepartmentId { get; set; }
        public string Details { get; set; }
        public int RequestStatusId { get; set; }
        public virtual ICollection<RequestsLog> RequestLogs { get; set; }
    }
}
