using Edublock.Enumerations;

namespace Edublock.Models
{
    public class RequestStatus : BaseEntity
    {
        public string Name { get; set; }
        public virtual RequestState State { get; set; }
        public int PositionOrder { get; set; }

        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }

        public virtual ICollection<Request> Requests { get; set; }
        public virtual ICollection<RequestsLog> RequestsLogs { get; set; }
    }
}
