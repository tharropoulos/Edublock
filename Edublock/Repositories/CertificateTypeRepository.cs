using Edublock.Data;
using Edublock.Models;
using Edublock.Repositories.IRepositories;

namespace Edublock.Repositories
{
    public class CertificateTypeRepository :  BaseRepository<CertificateType>, ICertificateTypeRepository
    {
        private readonly ApplicationDbContext _context;
        public CertificateTypeRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
