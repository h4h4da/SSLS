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
        IQueryable<Reader> Readers { get; }
        void SaveBook(Book book);

        Book DeleteBook(int id);

        void SaveCategory(Category category);

        Category DeleteCategory(int id);
    }
}
