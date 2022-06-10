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
        public Task<CategoryDto> Insert(CategoryInsertDto categoryDto);
        Task<CategoryDto> GetById(int id);
        Task<CategoryDto> Update(int id, CategoryInsertDto categoryDto);
        Task Delete(int id);
    }
}
