using Edublock.Data;
using Edublock.Models;
using Edublock.Repositories.Interfaces;

namespace Edublock.Repositories
{
    public class UniversityRepository : BaseRepository<University>, IUniversityRepository
    {
        private readonly ApplicationDbContext _context;
        public UniversityRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
