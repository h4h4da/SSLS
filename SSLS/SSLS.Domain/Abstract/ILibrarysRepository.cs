using SSLS.Domain.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSLS.Domain.Abstract
{
    public interface ILibrarysRepository
    {
        IQueryable<Book> Books { get; }
        IQueryable<Category> Categories { get; }
    }
}
