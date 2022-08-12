namespace Edublock.Models
{
    public class RequestsLog : BaseEntity
    {
        public string Comment { get; set; }

        public int RequestId { get; set; }
        public Request Request { get; set; }

        public int CurrentRequestStatusId { get; set; }
        public RequestStatus RequestStatus { get; set; }
    }
}
