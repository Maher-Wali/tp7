using tp4.Core.Entities;

namespace tp4.Services.CustomerService
{
    public interface ICustomerService
    {
        IEnumerable<Customer> GetAllCustomers();
        Customer GetById(int id);
        IEnumerable<Customer> GetCustomersWithMembershipType();
        void Add(Customer c);
        void Update(Customer c);
        void Delete(int id);
        IEnumerable<MembershipType> GetMembershipType();

    }
}
