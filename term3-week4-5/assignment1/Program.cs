using Model;

namespace assignment1
{
    public class Program
    {
        public void PrintHeader(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        public static void Main(string[] args)
        {
            Program myProgram = new Program();
            myProgram.Start();
        }

        void Start()
        {
            PrintHeader("testing customers");
            Customer customer1 = new Customer(1, "lionelmessi@hotmail.com", "Lionel", "Messi");
            Console.WriteLine(customer1.ToString());
            Customer customer2 = new Customer(2, "donhenley@gmail.com", "Don", "Henley");
            Console.WriteLine(customer2.ToString());
            Console.WriteLine();

            PrintHeader("testing books");
            Book book1 = new Book(1, "J.K. Rowling", "Harry Potter and the Prisoner of Azkaban");
            Console.WriteLine(book1.ToString());
            Book book2 = new Book(2, "Dan Brown", "The Da Vince Code");
            Console.WriteLine(book2.ToString());
            Console.WriteLine();

            PrintHeader("testing reservations");
            Reservation reservation1 = new Reservation(1, customer1, book2);
            Console.WriteLine(reservation1.ToString());
            Reservation reservation2 = new Reservation(2, customer2, book2);
            Console.WriteLine(reservation2.ToString());
        }
    }
}
