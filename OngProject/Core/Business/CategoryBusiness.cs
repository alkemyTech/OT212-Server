using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using OngProject.Core.Mapper;
using OngProject.Entities;
using OngProject.Repositories;
using OngProject.Core.Models.DTOs;
using OngProject.Core.Models;
using OngProject.Core.Helper;

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

            int totalItems = await CountElements();

            var list = categoriesList.Select(x => CategoryMapper.MapToCategoryNameDTO(x)).ToList();

            var pagelist = new PageList<CategoryNameDTO>(list, page, pageSize, totalItems, url);

            return pagelist;
        }

        public async Task<int> CountElements()
            => await _unitOfWork.CategoriesRepository.Count();

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

        public async Task<CategoryDto> Update(int id, CategoryInsertDto categoryDto)
        {
            var category = await _unitOfWork.CategoriesRepository.GetByIdAsync(id);

            if (category != null)
            {
                var image = await ImageUploadHelper.UpdateImage(category.Image, categoryDto.Image);

                category.Name = categoryDto.Name;
                category.Description= categoryDto.Description;
                category.Image = image;


                await _unitOfWork.CategoriesRepository.UpdateAsync(category);
                await _unitOfWork.SaveAsync();

                return category.MapToCategoryDto();
            }
            throw new KeyNotFoundException();
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
