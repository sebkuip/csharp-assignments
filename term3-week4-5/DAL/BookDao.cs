using Model;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class BookDao : BaseDao
    {
        public List<Book> GetAll()
        {
            string query = "SELECT Id, Title, Author FROM books";
            SqlParameter[] parameters = new SqlParameter[0];
            return ReadBooks(ExecuteSelectQuery(query, parameters));
        }

        public List<Book> ReadBooks(DataTable dt)
        {
            List<Book> books = new List<Book>();
            foreach (DataRow row in dt.Rows)
            {
                Book book = new Book(
                    (int)row["Id"],
                    (string)row["Title"],
                    (string)row["Author"]
                    );
                books.Add(book);
            }
            return books;
        }

        public Book GetById(int bookId)
        {
            string query = "SELECT Id, Title, Author FROM books WHERE Id = @Id";
            SqlParameter[] parameters = new SqlParameter[1]
            {
                new SqlParameter("@Id", bookId)
            };
            return ReadBook(ExecuteSelectQuery(query, parameters));
        }

        public Book ReadBook(DataTable dt)
        {
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            DataRow row = dt.Rows[0];
            return new Book(
                (int)row["Id"],
                (string)row["Author"],
                (string)row["Title"]
                );
        }

        public List<Book> GetByAuthor(string authorName)
        {
            string query = "SELECT Id, Title, Author FROM books WHERE Author = @Author";
            SqlParameter[] parameters = new SqlParameter[1]
            {
                new SqlParameter("@Author", authorName)
            };
            return ReadBooks(ExecuteSelectQuery(query, parameters));
        }
    }
}
