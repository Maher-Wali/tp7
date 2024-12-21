using tp4.Core.Entities;

namespace tp4.Core.Interfaces.Services
{
    public interface IMembershipTypeService
    {
        IEnumerable<MembershipType> GetAllMembershipTypes();
        MembershipType GetMembershipTypeById(int id);
    }
}
