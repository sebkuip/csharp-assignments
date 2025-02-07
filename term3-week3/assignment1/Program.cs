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
            store.Add(new Book("Dracula", "Bram Stoker", 15.00, 5));
            store.Add(new Book("Joe speedboot", "Tommy Wieringa", 12.50, 5));
            store.Add(new Magazine("Time", "Friday", 3.90, 10));
            store.Add(new Magazine("Donald Duck", "Thursday", 2.50, 8));
            store.Add(new Book("The hobbit", "J.R.R. Tolkien", 12.50, 4));

            store.PrintCompleteStock();
        }
    }

    internal abstract class StoreItem
    {
        public string Title
        {
            get; set;
        }

        public double Price
        {
            get; set;
        }

        public int Count
        {
            get; set;
        }

        public double totalPrice
        {
            get
            {
                return Count * Price;
            }
        }


        public StoreItem(string title, double price, int count)
        {
            this.Title = title;
            this.Price = price;
            this.Count = count;
        }

        public abstract void Print();
    }

    internal class Book : StoreItem
    {
        protected string Author
        {
            get;
        }

        public Book(string title, string author, double price, int count) : base(title, price, count)
        {
            this.Author = author;
        }

        public override void Print()
        {
            Console.WriteLine($"[Book] '{Title}' by {Author}, {Price.ToString("0.00")} ({Count}x)");
        }
    }

    internal class Magazine : StoreItem
    {
        protected string releaseDay;

        public Magazine(string title, string releaseDay, double price, int count) : base(title, price, count)
        {
            this.releaseDay = releaseDay;
        }

        public override void Print()
        {
            Console.WriteLine($"[Magazine] {Title} - release day: {releaseDay}, {Price.ToString("0.00")} ({Count}x)");
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
            foreach (StoreItem item in stock)
            {
                item.Print();
                price += item.totalPrice;
            }
            string priceString = price.ToString("0.00");
            Console.WriteLine($"\nTotal sales price: {priceString}");
        }
    }
}
