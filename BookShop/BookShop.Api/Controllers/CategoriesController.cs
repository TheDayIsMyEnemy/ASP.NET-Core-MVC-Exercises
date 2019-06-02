using BookShop.Api.Extensions;
using BookShop.Api.Filters;
using BookShop.Api.Models.Categories;
using BookShop.Core.DTOs.Categories;
using BookShop.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookShop.Api.Controllers
{
    public class CategoriesController : BaseApiController
    {
        private readonly ICategoryService categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
            => Ok(await categoryService.ListAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
            => this.OkOrNotFound(await categoryService.GetByIdAsync(id));

        [HttpPut("{id}")]
        [ValidateModel]
        public async Task<IActionResult> Edit(int id, [FromBody]CategoryRequestModel model)
        {
            if (await categoryService.CategoryExistsAsync(model.Name))
            {
                return BadRequest("Category already exists.");
            }

            CategoryDto category = await categoryService.EditCategoryAsync(id, model.Name);
            return Ok(category);
        }

        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> Create([FromBody]CategoryRequestModel model)
        {
            if (await categoryService.CategoryExistsAsync(model.Name))
            {
                return BadRequest("Category already exists.");
            }

            int categoryId = await categoryService.CreateCategoryAsync(model.Name);
            return Ok(categoryId);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
            => this.OkOrNotFound(await categoryService.DeleteCategoryAsync(id));
    }
}
