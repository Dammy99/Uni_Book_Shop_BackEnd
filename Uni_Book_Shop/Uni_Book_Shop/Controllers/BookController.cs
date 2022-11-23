using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Uni_Book_Shop.Data.Context;
using Uni_Book_Shop.Data.Services.Interface;

namespace Uni_Book_Shop.WebApi.Controllers
{
    [Route("api/[controller]")]
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
        [HttpGet]
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

        //[HttpGet("checkBox")]
        //public async Task<IActionResult> GetCheckedBooks(List<Enum> searched)
        //{
        //    var one_book = await _service.GetBooksByCheckbox(searched);
        //    return Ok(one_book);
        //}
    }
}
