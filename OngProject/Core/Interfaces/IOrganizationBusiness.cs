using OngProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Core.Interfaces
{
    public interface IOrganizationBusiness
    {
        Organization GetById(int id);

        List<Organization> GetAll();

        void Insert(Organization entity);

        void Update(Organization entity);

        void Delete(Organization entity);
    }
}
