using tp4.Core.Interfaces.Repositories;
using tp4.Application.DTOs;

namespace tp4.Application.UseCases.MembershipTypes
{
    public class GetAllMembershipTypes
    {
        private readonly IMembershipTypeRepository _membershipTypeRepository;

        public GetAllMembershipTypes(IMembershipTypeRepository membershipTypeRepository)
        {
            _membershipTypeRepository = membershipTypeRepository;
        }

        public async Task<IEnumerable<MembershipTypeDto>> ExecuteAsync()
        {
            var membershipTypes = await _membershipTypeRepository.GetAllAsync();

            return membershipTypes.Select(mt => new MembershipTypeDto
            {
                Id = mt.Id,
                Name = mt.Name,
                SignUpFee = mt.SignUpfee,
                DurationInMonths = mt.DurationInMonth,
                DiscountRate = mt.discountRate
            });
        }
    }
}
