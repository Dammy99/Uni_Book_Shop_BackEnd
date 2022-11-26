using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uni_Book_Shop.Data.Extentions;

namespace Uni_Book_Shop.Data.Services.Interface
{
    public interface IBookService
    {
        Task<IReadOnlyList<Book>> GetAllBooksAsync();
        Task<IReadOnlyList<Book>> GetSearchedBooks(string searched);
        Task<Book> GetBookByIdAsync(int id);
        Task<IReadOnlyList<Book>> GetBooksWithAllParametresAsync( string searched, List<string> vs);
        IReadOnlyList<Book> GetPaginatedList(int page, IReadOnlyList<Book> books);
        int GetAmountOfBooks(IReadOnlyList<Book> books);
        //Task<IReadOnlyList<Book>> GetBooksByCheckbox(List<Enum> ts);
    }
}
