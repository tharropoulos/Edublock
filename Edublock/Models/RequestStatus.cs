using Edublock.Enumerations;

namespace Edublock.Models
{
    public class RequestStatus : BaseEntity
    {
        public string Name { get; set; }
        public RequestState State { get; set; }
        public int PositionOrder { get; set; }

        public int DepartmentId { get; set; }
        public Department Department { get; set; }

        public ICollection<Request> Requests { get; set; }
    }
}
