using OngProject.Entities;
using System.Collections.Generic;

namespace OngProject.Core.Interfaces
{
    public interface IUserBusiness
    {
        public User GetById(int id);
        public List<User> GetAll();
        public void Insert(User user);
        public void Update(User user);
        public void Delete(User user);
    }
}