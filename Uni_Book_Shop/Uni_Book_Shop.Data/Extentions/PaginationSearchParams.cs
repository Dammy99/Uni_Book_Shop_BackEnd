using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uni_Book_Shop.Data.Extentions
{
    public class PaginationSearchParams
    {

        [FromQuery]
        public int Page { get; set; }
        [FromQuery]
        public string q { get; set; } = string.Empty;
        [FromQuery]
        public IReadOnlyList<string>? theme { get; set; }


    }
}
