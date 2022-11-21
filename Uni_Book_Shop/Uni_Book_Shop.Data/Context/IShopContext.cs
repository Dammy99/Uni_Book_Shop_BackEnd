using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uni_Book_Shop.Data.Context
{
    public interface IShopContext
    {
        public DbSet<Book> Books { get; set; }
    }
}
