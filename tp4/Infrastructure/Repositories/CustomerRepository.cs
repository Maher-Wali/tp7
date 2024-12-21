using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using tp4.Core.Entities;
using tp4.Core.Interfaces;
using tp4.Core.Interfaces.Repositories;
using tp4.Repositories;

namespace tp4.Infrastructure.Repositories
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        private readonly ApplicationDbContext _context;
        protected readonly DbSet<Customer> _dbSet;

        public CustomerRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
            _dbSet = _context.Set<Customer>();
        }

        public IEnumerable<Customer> GetCustomersWithMembershipType()
        {
            return _context.Customers.Include(c => c.membershiptype).ToList();
        }

        public IEnumerable<MembershipType> GetMembershipType()
        {
            return _context.MembershipTypes.ToList();
        }

        public IEnumerable<Movie> GetFavoriteMovies(int customerId)
        {
            return _context.Customers
                .Include(c => c.FavoriteMovies)
                .FirstOrDefault(c => c.Id == customerId)?
                .FavoriteMovies;
        }

        public async Task<Customer> GetByIdAsync(int id)
        {
            return await _context.Customers.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task UpdateAsync(Customer customer)
        {
            _context.Customers.Update(customer);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var customer = await _dbSet.FindAsync(id); // Find the customer by ID asynchronously
            if (customer != null)
            {
                _dbSet.Remove(customer); // Remove the customer entity
                await _context.SaveChangesAsync(); // Save changes asynchronously
            }
        }

    }
}
