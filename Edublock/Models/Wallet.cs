using Edublock.Data;

namespace Edublock.Models
{
    public class Wallet : BaseEntity
    {
        public string? Description { get; set; }

        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; } = default!;
        
        public ICollection<Certificate>? Certificates { get; set; }
    }
}
