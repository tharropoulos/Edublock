using Edublock.Data;

namespace Edublock.Models
{
    public class Request : BaseEntity
    {
        public string Details { get; set; }

        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
    }
}
