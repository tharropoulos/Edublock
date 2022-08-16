﻿using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using Edublock.Models;
namespace Edublock.Data
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;

        [ForeignKey("Wallet")]
        public int? WalletId { get; set; }
        public virtual  Wallet Wallet { get; set; }

        public virtual ICollection<UserUniversityLink> UniversityLinks { get; set; }
        public virtual ICollection<Request> Requests { get; set; }

    }
}
