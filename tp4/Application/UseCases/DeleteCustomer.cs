using tp4.Core.Interfaces.Repositories;

namespace tp4.Application.UseCases.Customers
{
    public class DeleteCustomer
    {
        private readonly ICustomerRepository _customerRepository;

        public DeleteCustomer(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task ExecuteAsync(int customerId)
        {
            var customer = await _customerRepository.GetByIdAsync(customerId);
            if (customer == null)
                throw new Exception("Customer not found!");

            await _customerRepository.DeleteAsync(customer.Id);
        }
    }
}
