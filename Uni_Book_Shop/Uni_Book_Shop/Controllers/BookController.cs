using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Text.Json;
using Uni_Book_Shop.Data.Context;
using Uni_Book_Shop.Data.Extentions;
using Uni_Book_Shop.Data.Services.Interface;

namespace Uni_Book_Shop.WebApi.Controllers
{
    [Route("api/books")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly ShopContext _context;
        private readonly IBookService _service;
        public BookController(ShopContext context, IBookService service)
        {
            _context = context;
            _service = service;
        }
        [HttpGet("wwwwww")]
        public async Task<IActionResult> GetBooks()
        {
            var book_list = await _service.GetAllBooksAsync();
            return Ok(book_list);
        }
        [HttpGet("search")]
        public async Task<IActionResult> GetBookBySearch(string searched)
        {
            var one_book = await _service.GetSearchedBooks(searched);
            return Ok(one_book);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> BookByID(int id)
        {
            return Ok(await _service.GetBookByIdAsync(id));
        }

        [HttpGet]
        public async Task<IActionResult> BooksWithParamentres(
            [FromQuery] PaginationSearchParams @params)
        {
            var book_list = await _service.GetBooksWithAllParametresAsync(@params.q, @params.theme!);

            Response.Headers.Add("X-TotalCount", JsonSerializer.Serialize(_service.GetAmountOfBooks(book_list)));

            book_list = _service.GetPaginatedList(@params.Page, book_list);

            return Ok(book_list);
        }

        [HttpGet("themes")]
        public async Task<IActionResult> ThemesFromBooks()
        {
            return Ok(await _service.GetAllExistThemes());
        }
    }
}
