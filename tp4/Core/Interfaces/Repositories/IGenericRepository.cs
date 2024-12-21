using System.Collections.Generic;

namespace tp4.Core.Interfaces.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        void Add(T entity);
        void Update(T entity);
        void Delete(int id);
        Task<T> GetByIdAsync(int id); // Add this method
        Task UpdateAsync(T entity); // Add this method
        Task<IEnumerable<T>> GetAllAsync();
        Task AddAsync(T entity);
        Task DeleteAsync(int id);
    }
}
