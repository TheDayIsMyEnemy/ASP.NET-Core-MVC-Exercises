using BookShop.Core.DTOs.Categories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookShop.Core.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDto>> ListAllAsync();

        Task<CategoryDto> GetByIdAsync(int id);

        Task<CategoryDto> EditCategoryAsync(int id, string name);

        Task<CategoryDto> DeleteCategoryAsync(int id);

        Task<int> CreateCategoryAsync(string name);

        Task<bool> CategoryExistsAsync(string name);
    }
}
