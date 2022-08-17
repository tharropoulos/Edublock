using Edublock.Data;
using Edublock.Models;
using Edublock.Repositories.Interfaces;

namespace Edublock.Repositories
{
    public class CertificateRepository : BaseRepository<Certificate>, ICertificateRepository
    {
        private readonly ApplicationDbContext _context;
        public CertificateRepository(ApplicationDbContext context) : base(context)
        {
        }

    }
}
