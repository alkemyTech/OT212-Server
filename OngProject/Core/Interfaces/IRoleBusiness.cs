using OngProject.Entities;
using System.Collections.Generic;

namespace OngProject.Core.Interfaces
{
    public interface IRoleBusiness
    {
        Role GetById(int id);

        List<Role> GetAll();

        void Insert(Role entity);

        void Update(Role entity);

        void Delete(Role entity);
    }
}
