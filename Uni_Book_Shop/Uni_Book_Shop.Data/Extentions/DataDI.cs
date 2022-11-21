using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uni_Book_Shop.Data.Context;
using Uni_Book_Shop.Data.Services.Implementation;
using Uni_Book_Shop.Data.Services.Interface;

namespace Uni_Book_Shop.Data.Extentions
{
    public static class DataDI
    {
        public static void AddDomainDataServices(this IServiceCollection services)
        {
            services.AddDbContext<IShopContext, ShopContext>();
        }
        public static void AddDI(this IServiceCollection services)
        {
            services.AddScoped<IBookService, BookService>();
        }
    }
}
