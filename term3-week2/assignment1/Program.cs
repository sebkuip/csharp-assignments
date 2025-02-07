namespace assignment1
{
    using System;
    using System.Globalization;
    using System.Threading;
    internal class Program
    {
        static void Main(string[] args)
        {
            CultureInfo ci = new CultureInfo("en-US");
            Thread.CurrentThread.CurrentCulture = ci;
            Thread.CurrentThread.CurrentUICulture = ci;

            BookStore store = new BookStore();
            store.Add(new Book("Dracula", "Bram Stoker", 15.00));
            store.Add(new Book("Joe speedboot", "Tommy Wieringa", 12.50));
            store.Add(new Magazine("Time", "Friday", 3.90));
            store.Add(new Magazine("Donald Duck", "Thursday", 2.50));
            store.Add(new Book("The hobbit", "J.R.R. Tolkien", 12.50));

            store.PrintCompleteStock();
        }
    }

    internal abstract class StoreItem
    {
        public string title;
        public double price;

        public StoreItem (string title, double price)
        {
            this.title = title;
            this.price = price;
        }

        public abstract void Print();
    }

    internal class Book: StoreItem
    {
        protected string author;

        public Book (string title, string author, double price) : base(title, price)
        {
            this.author = author;
        }

        public override void Print()
        {
            Console.WriteLine($"[Book] '{title}' by {author}, {price.ToString("0.00")}");
        }
    }

    internal class Magazine: StoreItem
    {
        protected string releaseDay;

        public Magazine (string title, string releaseDay, double price): base(title, price)
        {
            this.releaseDay = releaseDay;
        }

        public override void Print()
        {
            Console.WriteLine($"[Magazine] {title} - release day: {releaseDay}, {price.ToString("0.00")}");
        }
    }

    internal class BookStore
    {
        private List<StoreItem> stock = new List<StoreItem>();

        public void Add(StoreItem item)
        {
            stock.Add(item);
        }

        public void PrintCompleteStock()
        {
            double price = 0.00;
            foreach(StoreItem item in stock)
            {
                item.Print();
                price += item.price;
            }
            string priceString = price.ToString("0.00");
            Console.WriteLine($"\nTotal sales price: {priceString}");
        }
    }
}
