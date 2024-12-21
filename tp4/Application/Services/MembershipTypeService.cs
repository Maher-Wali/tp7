using tp4.Core.Entities;
using tp4.Core.Interfaces.Repositories;
using tp4.Core.Interfaces.Services;

namespace tp4.Application.Services
{
    public class MembershipTypeService : IMembershipTypeService
    {
        private readonly IMembershipTypeRepository _membershipTypeRepository;

        public MembershipTypeService(IMembershipTypeRepository membershipTypeRepository)
        {
            _membershipTypeRepository = membershipTypeRepository;
        }

        public IEnumerable<MembershipType> GetAllMembershipTypes()
        {
            return _membershipTypeRepository.GetAll();
        }

        public MembershipType GetMembershipTypeById(int id)
        {
            return _membershipTypeRepository.GetById(id);
        }
    }
}
