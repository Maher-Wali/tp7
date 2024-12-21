using tp4.Core.Entities;

namespace tp4.Core.Interfaces.Services
{
    public interface ICustomerService
    {
        IEnumerable<Customer> GetAllCustomers();
        Customer GetCustomerById(int id);
        void CreateCustomer(Customer customer);
        void UpdateCustomer(Customer customer);
        void DeleteCustomer(int id);
        IEnumerable<Customer> GetCustomersWithMembershipType();
        IEnumerable<Movie> GetFavoriteMovies(int customerId);

    }
}
