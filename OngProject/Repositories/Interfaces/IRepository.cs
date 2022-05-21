using OngProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Repositories.Interfaces
{
    public interface IRepository<T> where T : Entity
    {
        T GetById(int id);
        List<T> GetAll();

        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        void SoftDelete(T entity);

    }
}
