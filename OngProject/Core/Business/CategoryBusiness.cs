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

        public async Task<PageList<CategoryNameDTO>> GetAll(int page, int pageSize = 10, string url = "")
        {
            var query = new QueryProperty<Category>(page, pageSize);
            var categoriesList = await _unitOfWork.CategoriesRepository.GetAllAsync(query);
            
            var totalItems = await _unitOfWork.CategoriesRepository.Count();

            var list = categoriesList.Select(x => CategoryMapper.MapToCategoryNameDTO(x)).ToList();

            var pagelist = new PageList<CategoryNameDTO>(list, page, pageSize, totalItems, url);

            return pagelist;
        }

        public async Task<CategoryDto> GetById(int id)
        {
            var entity = await _unitOfWork.CategoriesRepository.GetByIdAsync(id);

            if (entity == null || entity.IsDeleted == true)
                return null;
                
            return CategoryMapper.MapToCategoryDto(entity);
        }

        public async Task<CategoryDto> Insert(CategoryInsertDto categoryDto)
        {
            try
            {
                var category = await CategoryMapper.MapToCategoryInsertDto(categoryDto);
                await _unitOfWork.CategoriesRepository.InsertAsync(category);
                await _unitOfWork.SaveAsync();
                return CategoryMapper.MapToCategoryDto(category);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + " Check if name is string and not empty.");
            }            
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
