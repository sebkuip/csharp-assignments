using DAL;
using Model;


namespace ReservationSystemService
{
    public class BookService
    {
        private BookDao bookDao = new BookDao();
        public List<Book> GetAll()
        {
            return bookDao.GetAll();
        }

        public Book GetById(int bookId)
        {
            return bookDao.GetById(bookId);
        }

        public List<Book> GetByAuthor(string authorName)
        {
            return bookDao.GetByAuthor(authorName);
        }
    }
}
