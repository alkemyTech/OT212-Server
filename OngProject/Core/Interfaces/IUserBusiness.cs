using OngProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Core.Interfaces
{
    public interface IUserBusiness 
    {
        User GetById(int id);
        List<User> GetAll();
        void Insert (User user);
        void Update (User user);
        void Delete (User user);
    }
}
