using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uni_Book_Shop.Data.Context;
using Uni_Book_Shop.Data.Services.Interface;

namespace Uni_Book_Shop.Data.Services.Implementation
{
    public class BookService : IBookService
    {
        private readonly IShopContext _context;
        public BookService(IShopContext context)
        {
            _context = context;
        }
        public async Task<IReadOnlyList<Book>> GetAllBooksAsync()
        {
            var book_list = _context.Books;
            return await book_list.ToListAsync();
        }

        public async Task<IReadOnlyList<Book>> GetSearchedBooks(string searched)
        {
            var book_list = _context.Books.Where(x => x.Name.Contains(searched)).ToListAsync();
            return await book_list;
        }

        //public Task<IReadOnlyList<Book>> GetBooksByCheckbox(List<Enum> ts)
        //{
        //    var book_list = _context.Books.Where(x=> x.Theme.Contains(WhatToSearch(ts));
        //    return book_list;
        //}

        //private List<string> WhatToSearch(List<Enum> checkTypes)
        //{
        //    var Kaka = new List<string>();
        //    foreach (var checkType in checkTypes)
        //        Kaka.Add(checkType.ToString());
        //    return Kaka;
        //}

        //public enum CheckType
        //{
        //    Detective, Philosophical
        //}

    }
}
