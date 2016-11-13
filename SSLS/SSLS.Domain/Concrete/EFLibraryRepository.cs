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

        public IQueryable<Reader> Readers
        {
            get { return db.Reader; }
        }

        public void SaveBook(Book book)
        {
            if (book.Id == 0)
            {
                db.Book.Add(book);
            }
            else
            {
                Book dbEntry = db.Book.Find(book.Id);
                if (dbEntry != null)
                {
                    dbEntry.Authors = book.Authors;
                    dbEntry.Description = book.Description;
                    dbEntry.Name = book.Name;
                    dbEntry.Price = book.Price;
                    dbEntry.PublishDate = book.PublishDate;
                }
            }
            db.SaveChanges();
        }

        public Book DeleteBook(int id)
        {
            Book deletedBook = db.Book.Find(id);
            if (deletedBook != null)
            {
                db.Book.Remove(deletedBook);
                db.SaveChanges();
            }
            return deletedBook;
        }

        public void SaveCategory(Category category)
        {
            if (category.Id == 0)
            {
                db.Category.Add(category);
            }
            else
            {
                Category dbEntry = db.Category.Find(category.Id);
                if (dbEntry != null)
                {
                    dbEntry.Name = category.Name;
                }
            }
            db.SaveChanges();
        }

        public Category DeleteCategory(int id)
        {
            Category dbEntry = db.Category.Find(id);
            if (dbEntry != null)
            {
                db.Category.Remove(dbEntry);
                db.SaveChanges();
            }

            return dbEntry;
        }
    }
}
