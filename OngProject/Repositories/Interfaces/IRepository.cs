using OngProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Repositories.Interfaces
{
    public interface IRepository<T> where T : Entity
    {
        Task<T> GetByIdAsync(int id);
        Task<T> GetAsync(QueryProperty<T> query);
        Task<List<T>> GetAllAsync();
        Task<List<T>> GetAllAsync(QueryProperty<T> query);
        Task InsertAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task SoftDeleteAsync(T entity);

        Task<int> Count();
    }
}
