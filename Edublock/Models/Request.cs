using Edublock.Data;

namespace Edublock.Models
{
    public class Request : BaseEntity
    {
        public string Details { get; set; }

        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }

        public int? DepartmentId { get; set; }
        public virtual Department Department { get; set; }

        public int RequestStatusId { get; set; }
        public virtual RequestStatus RequestStatus { get; set; }

        public virtual ICollection<RequestsLog> RequestsLogs { get; set; }
        public virtual ICollection<Certificate> Certificates { get; set; }

    }
}
