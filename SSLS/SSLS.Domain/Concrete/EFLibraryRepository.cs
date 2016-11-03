using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SSLS.Domain.Abstract;
namespace SSLS.Domain.Concrete
{
    public class EFLibraryRepository : ILibrarysRepository
    {
        private SSLSEntities db = new SSLSEntities();

        public IQueryable<Category> Categories
        {
            get { return db.Category; }
        }

        public IQueryable<Book> Books
        {
            get { return db.Book; }
        }

       
    }
}
