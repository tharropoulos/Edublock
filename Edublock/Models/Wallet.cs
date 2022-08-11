using Edublock.Data;

namespace Edublock.Models
{
    public class Wallet
    {
        public int WalletId { get; set; }
        public string? WalletDescription { get; set; }
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; } = default!;
        public ICollection<Certificate>? Certificates { get; set; }
    }
}
