using AutoMapper;
using BookShop.Core.DTOs.Categories;
using BookShop.Core.Entities;
using BookShop.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Core.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IMapper mapper;
        private readonly ICategoryRepository categoryRepository;

        public CategoryService(IMapper mapper, ICategoryRepository categoryRepository)
        {
            this.mapper = mapper;
            this.categoryRepository = categoryRepository;
        }

        public async Task<bool> CategoryExistsAsync(string name)
            => await categoryRepository.ExistsAsync(name);

        public async Task<int> CreateCategoryAsync(string name)
        {
            if (!await categoryRepository.ExistsAsync(name))
            {
                Category category = new Category { Name = name };
                await categoryRepository.CreateAsync(category);
                return category.Id;
            }
            return 0;
        }

        public async Task<CategoryDto> DeleteCategoryAsync(int id)
        {
            Category category = await categoryRepository.GetByIdAsync(id);

            if (category != null)
            {
                await categoryRepository.DeleteAsync(category);
            }
            return mapper.Map<Category, CategoryDto>(category);
        }

        public async Task<CategoryDto> EditCategoryAsync(int id, string name)
        {
            var category = await categoryRepository.GetByIdAsync(id);

            if (category != null && !await categoryRepository.ExistsAsync(name))
            {
                category.Name = name;
                await categoryRepository.UpdateAsync(category);
                return mapper.Map<Category, CategoryDto>(category);
            }
            return null;
        }

        public async Task<CategoryDto> GetByIdAsync(int id)
        {
            var category = await categoryRepository.GetByIdAsync(id);
            return mapper.Map<Category, CategoryDto>(category);
        }

        public async Task<IEnumerable<CategoryDto>> ListAllAsync()
        {
            var categories = await categoryRepository.ListAllAsync();
            return mapper.Map<ICollection<Category>, IEnumerable<CategoryDto>>(categories);
        }
    }
}
