using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uni_Book_Shop.Data.Extentions
{
    public class Constants
    {
        private const int itemsPerPage = 6;
        public static int ItemsPerPage { get { return itemsPerPage; } }

        //private readonly Dictionary<string, string> themes = new()
        //{
        //    { "детектив", "Детектив" },
        //    { "пригоди", "Пригоди" }
        //};
        //public Dictionary<string, string> Themes => themes;
    }
}
