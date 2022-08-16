namespace Edublock.Models
{
    public class RequestsLog : BaseEntity
    {
        public string Comment { get; set; }

        public int RequestId { get; set; }
        public virtual Request Request { get; set; }

        public int CurrentRequestStatusId { get; set; }
        public virtual RequestStatus RequestStatus { get; set; }
    }
}
