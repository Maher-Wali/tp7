using tp4.Core.Interfaces.Repositories;

namespace tp4.Application.UseCases.MembershipTypes
{
    public class AssignMembershipType
    {
        private readonly ICustomerRepository _customerRepository;

        public AssignMembershipType(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task ExecuteAsync(int customerId, int membershipTypeId)
        {
            var customer = await _customerRepository.GetByIdAsync(customerId);
            if (customer == null)
                throw new Exception("Customer not found!");

            customer.MembershipTypeId = membershipTypeId;

            await _customerRepository.UpdateAsync(customer);
        }
    }
}
