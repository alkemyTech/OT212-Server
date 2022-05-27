using OngProject.Core.Mapper;
using OngProject.Core.Models.DTOs;
using OngProject.Entities;
using OngProject.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Core.Business
{
    public class CategoryBusiness: ICategoryBusiness
    {
        private readonly UnitOfWork _unitOfWork;

        public CategoryBusiness(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<CategoryNameDTO>> GetAll()
        {
            var categoriesList = await _unitOfWork.CategoriesRepository.GetAllAsync();

            return categoriesList.Select(x => CategoryMapper.MapToCategoryNameDTO(x)).ToList();
        }

        public Task<Category> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task Insert(Category entity)
        {
            throw new NotImplementedException();
        }

        public Task Update(Category entity)
        {
            throw new NotImplementedException();
        }
        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
