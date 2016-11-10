using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSLS.Domain.Concrete
{
    public class Cart
    {

        private List<CartLine> lineCollection = new List<CartLine>();
        public void AddItem(Book p, int quantity)
        {
            CartLine line = lineCollection.Where(e => e.Book.Id == p.Id).FirstOrDefault();
            if (line == null)
            {
                lineCollection.Add(new CartLine { Book = p, Quantity = quantity });
            }
            else line.Quantity += quantity;
        }
        public int AddSingleItem(Book p)
        {
            CartLine line = lineCollection.Where(e => e.Book.Id == p.Id).FirstOrDefault();
            if (line == null)
            {
                lineCollection.Add(new CartLine { Book = p, Quantity = 1 });
                return 1;
            }
            else return -1;
        }


        public void Clear()
        {
            lineCollection.Clear();
        }
      
        public IEnumerable<CartLine> Line { get { return lineCollection; } }

        public void RemoveLine(Book p)
        {
            lineCollection.RemoveAll(e => e.Book.Id == p.Id);
        }
        public bool FindBookInCart(int Id)
        {
            CartLine line = lineCollection.Where(e => e.Book.Id == Id).FirstOrDefault();
            if (line != null) return true;
            else return false;

        }
    }
}
