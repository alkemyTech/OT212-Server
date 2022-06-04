using OngProject.Entities;
using OngProject.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using OngProject.Core.Mapper;
using OngProject.Core.Models.DTOs;
using System.Linq;

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

        public async Task<CategoryDto> GetById(int id)
        {
            var entity = await _unitOfWork.CategoriesRepository.GetByIdAsync(id);
            if (entity == null)
                return null;
            return CategoryMapper.MapToCategoryDto(entity);
        }

        public Task Insert(Category entity)
        {
            throw new NotImplementedException();
        }

        public Task Update(Category entity)
        {
            throw new NotImplementedException();
        }
        public async Task Delete(int id)
        {
            var entity = await _unitOfWork.CategoriesRepository.GetByIdAsync(id);
            if (entity == null)
                throw new KeyNotFoundException();
            await _unitOfWork.CategoriesRepository.SoftDeleteAsync(entity);
            await _unitOfWork.SaveAsync();
        }
    }
}
