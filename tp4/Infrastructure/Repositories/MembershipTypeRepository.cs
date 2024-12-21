using tp4.Core.Entities;
using tp4.Core.Interfaces;
using tp4.Core.Interfaces.Repositories;
using tp4.Repositories;

namespace tp4.Infrastructure.Repositories
{
    public class MembershipTypeRepository : GenericRepository<MembershipType>, IMembershipTypeRepository
    {
        public MembershipTypeRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
