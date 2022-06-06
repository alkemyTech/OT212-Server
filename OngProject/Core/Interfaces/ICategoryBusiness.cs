using OngProject.Core.Models.DTOs;
using OngProject.Entities;
using OngProject.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OngProject.Core.Business
{
    public interface ICategoryBusiness
    {
        Task<List<CategoryNameDTO>> GetAll();

        Task<Category> GetById(int id);
        public Task<CategoryDto> Insert(CategoryInsertDto categoryDto);

        Task<CategoryDto> GetById(int id);
        Task Insert(Category entity);

        Task Update(Category entity);
        Task Delete(int id);
    }
}
