using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uni_Book_Shop.Data.Context;
using Uni_Book_Shop.Data.Extentions;
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
        public async Task<Book> GetBookByIdAsync(int id)
        {
            var id_book = await _context.Books.FirstAsync(x => x.Id == id);
            return id_book;
        }

        public async Task<IReadOnlyList<Book>> GetBooksWithAllParametresAsync(string searched, IReadOnlyList<string> vs)
        {
            var needed_books = await _context.Books.ToListAsync();

            if (!string.IsNullOrEmpty(searched))
            {
                needed_books = await _context.Books.Where(x => x.Name.Contains(searched)).ToListAsync();
            }

            if (vs != null)
            {
                List<string> list = new();
                var people = new Dictionary<string, string>()
                {
                    { "детектив", "Детектив" },
                    { "пригоди", "Пригоди" }
                };
                foreach (var item in people)
                {
                    if (vs.Any(x=> x == item.Key))
                    {
                        list.Add(item.Value);
                    }
                }

                needed_books = needed_books.Where(x => list.Any(y=> y == x.Theme)).ToList();

                //needed_books = needed_books.Where(x => vs.Any(y => y == x.Theme)).ToList();
            }

            return needed_books;
        }

        public IReadOnlyList<Book> GetPaginatedList(int page, IReadOnlyList<Book> books)
        {
            books = books.Skip((page - 1) * Constants.ItemsPerPage)
                .Take(Constants.ItemsPerPage).ToList();
            return books;
        }

        public int GetAmountOfBooks(IReadOnlyList<Book> books)
        {
            var amount = books.Count();
            return amount;
        }

        public async Task<IReadOnlyList<string>> GetAllExistThemes()
        {
            var themes_list = await _context.Books.Select(x => x.Theme).Distinct().ToListAsync();
            return themes_list;
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
