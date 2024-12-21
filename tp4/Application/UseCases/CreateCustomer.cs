using tp4.Core.Entities;
using tp4.Core.Interfaces.Repositories;
using tp4.Application.DTOs;

namespace tp4.Application.UseCases.Customers
{
    public class CreateCustomer
    {
        private readonly ICustomerRepository _customerRepository;

        public CreateCustomer(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task ExecuteAsync(CustomerDto customerDto)
        {
            var customer = new Customer
            {
                Name = customerDto.Name,
                Email = customerDto.Email,
                Age = customerDto.Age,
                MembershipTypeId = customerDto.MembershipTypeId
            };

            await _customerRepository.AddAsync(customer);
        }
    }
}
