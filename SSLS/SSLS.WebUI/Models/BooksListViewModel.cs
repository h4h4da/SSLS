using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SSLS.Domain.Concrete;

namespace SSLS.WebUI.Models
{
    public class BooksListViewModel
    {
        public string SearchBookStr { get; set; }
        public IEnumerable<Book> Books { get; set; }

        public PagingInfo paginginfo { get; set; }
        public int CurrentCategoryId { get; set; }
    }
}