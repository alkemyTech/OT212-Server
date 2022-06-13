using System.Threading.Tasks;
using OngProject.Core.Models;
using OngProject.Core.Models.DTOs;
using OngProject.Entities;

namespace OngProject.Core.Business
{
    public interface ICategoryBusiness
    {
        Task<int> CountElements();
        Task<CategoryDto> GetById(int id);
        Task<PageList<CategoryNameDTO>> GetAll(int page, int pageSize, string url);
        Task<CategoryDto> Insert(CategoryInsertDto categoryDto);
        Task<CategoryDto> Update(int id, CategoryInsertDto categoryDto);
        Task Delete(int id);
    }
}
