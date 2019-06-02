using BookShop.Api.Extensions;
using BookShop.Api.Filters;
using BookShop.Api.Models.Books;
using BookShop.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BookShop.Api.Controllers
{
    public class BooksController : BaseApiController
    {
        private readonly IBookService bookService;
        private readonly IAuthorService authorService;

        public BooksController(IBookService bookService, IAuthorService authorService)
        {
            this.bookService = bookService;
            this.authorService = authorService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
            => this.OkOrNotFound(await bookService.GetBookDetailsAsync(id));

        [HttpPut("{id}")]
        [ValidateModel]
        public async Task<IActionResult> Put(int id, [FromBody]BookEditRequestModel book)
            => this.OkOrNotFound(await bookService.EditBook(id, book.Title, book.Description, book.Price,
                book.Copies, book.Edition, book.AuthorId));

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
            => this.OkOrNotFound(await bookService.DeleteBookAsync(id));

        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> Post([FromBody]BookCreateRequestModel book)
        {
            if (!await authorService.AuthorExistsAsync(book.AuthorId))
            {
                return BadRequest("Author does not exist.");
            }

            int bookId = await bookService.CreateBookAsync(book.Title, book.Description, book.Price,
                book.Copies, book.Edition, book.AuthorId, book.Categories);

            return this.Ok(bookId);
        }

        public async Task<IActionResult> Search([FromQuery]string search)
            => this.OkOrNotFound(await bookService.SearchAsync(search, 10));
    }
}
