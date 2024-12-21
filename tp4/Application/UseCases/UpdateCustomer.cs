using tp4.Core.Interfaces.Repositories;
using tp4.Application.DTOs;

namespace tp4.Application.UseCases.Customers
{
    public class UpdateCustomer
    {
        private readonly ICustomerRepository _customerRepository;

        public UpdateCustomer(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task ExecuteAsync(int customerId, CustomerDto customerDto)
        {
            var customer = await _customerRepository.GetByIdAsync(customerId);
            if (customer == null)
                throw new Exception("Customer not found!");

            customer.Name = customerDto.Name;
            customer.Email = customerDto.Email;
            customer.Age = customerDto.Age;
            customer.MembershipTypeId = customerDto.MembershipTypeId;

            await _customerRepository.UpdateAsync(customer);
        }
    }
}
