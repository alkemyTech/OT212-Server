﻿using OngProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Core.Interfaces
{
    public interface IOrganizationBusiness
    {
        Task<List<Organization>> GetAll();

        Task<Organization> GetById(int id);

        Task Insert(Organization entity);

        Task Update(Organization entity);

        Task Delete(int id);
    }
}
