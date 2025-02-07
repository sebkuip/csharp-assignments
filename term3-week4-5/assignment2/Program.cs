using Model;
using DAL;

namespace assignment2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Program myProgram = new Program();
            myProgram.Start();
        }

        void Start()
        {
            CustomerDao customerDao = new CustomerDao();
            List<Customer> customers = customerDao.GetAll();
            foreach (Customer c in customers)
            {
                Console.WriteLine(c.ToString());
            }
            Console.WriteLine();

            Console.Write("Enter customer id: ");
            int id = int.Parse(Console.ReadLine());
            Customer customer = customerDao.GetById(id);
            if (customer == null)
            {
                Console.WriteLine($"No customer with id {id}");
            } else
            {
                Console.WriteLine(customer.ToString());
            }
            
            Console.WriteLine();

            BookDao bookDao = new BookDao();
            List<Book> books = bookDao.GetAll();
            foreach (Book b in books)
            {
                Console.WriteLine(b.ToString());
            }
            Console.WriteLine();

            Console.Write("Enter book id: ");
            id = int.Parse(Console.ReadLine());
            Book book = bookDao.GetById(id);
            if (book == null)
            {
                Console.WriteLine($"No book with id {id}");
            } else
            {
                Console.WriteLine(book.ToString());
            }
        }
    }
}
