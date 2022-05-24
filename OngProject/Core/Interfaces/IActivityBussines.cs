using OngProject.Entities;
using System.Collections.Generic;

namespace OngProject.Core.Interfaces
{
    public interface IActivityBussines
    {
        public List<Activity> GetAll();
        public Activity GetById();
        public void Insert();
        public void Update();
        public void Delete();
    }
}
