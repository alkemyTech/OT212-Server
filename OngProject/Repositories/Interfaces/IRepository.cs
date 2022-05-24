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
        Task<List<T>> GetAllAsync();

        void InsertAsync(T entity);
        void Update(T entity);
        void Delete(T entity);
        void SoftDelete(T entity);

    }
}
