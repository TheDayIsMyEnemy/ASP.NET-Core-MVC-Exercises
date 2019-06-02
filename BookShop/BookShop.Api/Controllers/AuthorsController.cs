using AutoMapper;
using BookShop.Api.Extensions;
using BookShop.Api.Filters;
using BookShop.Api.Models.Authors;
using BookShop.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BookShop.Api.Controllers
{
    public class AuthorsController : BaseApiController
    {
        private readonly IAuthorService authorService;

        public AuthorsController(IAuthorService authorService, IMapper mapper)
        {
            this.authorService = authorService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
            => this.OkOrNotFound(await authorService.GetAuthorWithBookTitlesByIdAsync(id));

        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> Post([FromBody]AuthorRequestModel author)
        {
            int id = await authorService.CreateAsync(author.FirstName, author.LastName);
            return Ok(id);
        }

        [HttpGet("{id}/books")]
        public async Task<IActionResult> GetBooks(int id)
            => this.OkOrNotFound(await authorService.GetBooksByAuthorAsync(id));
    }
}
