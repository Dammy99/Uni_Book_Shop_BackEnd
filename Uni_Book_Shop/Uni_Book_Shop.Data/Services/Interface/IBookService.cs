using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uni_Book_Shop.Data.Services.Interface
{
    public interface IBookService
    {
        Task<IReadOnlyList<Book>> GetAllBooksAsync();
        Task<IReadOnlyList<Book>> GetSearchedBooks(string searched);
        //Task<IReadOnlyList<Book>> GetBooksByCheckbox(List<Enum> ts);
    }
}
