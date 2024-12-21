using tp4.Core.Interfaces.Repositories;
using tp4.Application.DTOs;

namespace tp4.Application.UseCases.Customers
{
    public class GetAllCustomers
    {
        private readonly ICustomerRepository _customerRepository;

        public GetAllCustomers(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<IEnumerable<CustomerDto>> ExecuteAsync()
        {
            var customers = await _customerRepository.GetAllAsync();

            return customers.Select(c => new CustomerDto
            {
                Id = c.Id,
                Name = c.Name,
                Email = c.Email,
                Age = c.Age,
                MembershipTypeId = c.MembershipTypeId
            });
        }
    }
}
