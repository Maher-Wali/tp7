using System.Collections.Generic;
using tp4.Core.Entities;

namespace tp4.Core.Interfaces.Repositories
{
    public interface ICustomerRepository : IGenericRepository<Customer>
    {
        IEnumerable<Customer> GetCustomersWithMembershipType();
        IEnumerable<MembershipType> GetMembershipType();
        IEnumerable<Movie> GetFavoriteMovies(int customerId);
    }
}
