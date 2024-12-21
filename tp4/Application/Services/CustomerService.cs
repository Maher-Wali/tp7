using tp4.Core.Entities;
using tp4.Core.Interfaces.Repositories;
using tp4.Core.Interfaces.Services;

namespace tp4.Application.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            return _customerRepository.GetAll();
        }

        public Customer GetCustomerById(int id)
        {
            return _customerRepository.GetById(id);
        }

        public void CreateCustomer(Customer customer)
        {
            _customerRepository.Add(customer);
        }

        public void UpdateCustomer(Customer customer)
        {
            _customerRepository.Update(customer);
        }

        public void DeleteCustomer(int id)
        {
            _customerRepository.Delete(id);
        }

        public IEnumerable<Customer> GetCustomersWithMembershipType()
        {
            return _customerRepository.GetCustomersWithMembershipType();
        }

        public IEnumerable<Movie> GetFavoriteMovies(int customerId)
        {
            return _customerRepository.GetFavoriteMovies(customerId);
        }
    }
}
