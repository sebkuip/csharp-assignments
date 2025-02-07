namespace assignment2
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

            Customer c1 = new Customer("Lionel Messi", DateTime.Parse("06/24/1987"));
            Reservation messiReservation = new Reservation(c1);
            Customer c2 = new Customer("Piet Paulusma", DateTime.Parse("12/15/1956"));
            Reservation paulusmaReservation = new Reservation(c2);

            Program myProgram = new Program();
            myProgram.PrintCustomer(c1);
            myProgram.PrintCustomer(c2);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("creating tickets (for Lionel Messi)");
            Console.ResetColor();
            try
            {
                // Lionel Messi

                Ticket t = new Ticket("Bohemian Rapsody", 10.50);
                t.StartTime = DateTime.Parse("02/13/2021 21:30");
                t.CinemaRoom = 1;
                t.MinimumAge = 6;
                messiReservation.Tickets.Add(t);
                string startTimeString = t.StartTime.ToString("dd/MM/yyy HH:mm");
                string priceString = t.Price.ToString("0.00");
                Console.WriteLine($"Created ticket '{t.MovieName}', start time: {startTimeString}, price: {priceString}, room: {t.CinemaRoom} ({t.MinimumAge}+)");

                t = new Ticket("The Prodigy", 10.50);
                t.StartTime = DateTime.Parse("02/13/2021 22:00");
                t.CinemaRoom = 4;
                t.MinimumAge = 16;
                messiReservation.Tickets.Add(t);
                startTimeString = t.StartTime.ToString("dd/MM/yyy HH:mm");
                priceString = t.Price.ToString("0.00");
                Console.WriteLine($"Created ticket '{t.MovieName}', start time: {startTimeString}, price: {priceString}, room: {t.CinemaRoom} ({t.MinimumAge}+)");

                t = new Ticket("Green Book", 10.50);
                t.StartTime = DateTime.Parse("02/15/2021 19:00");
                t.CinemaRoom = 5;
                t.MinimumAge = 12;
                messiReservation.Tickets.Add(t);
                startTimeString = t.StartTime.ToString("dd/MM/yyy HH:mm");
                priceString = t.Price.ToString("0.00");
                Console.WriteLine($"Created ticket '{t.MovieName}', start time: {startTimeString}, price: {priceString}, room: {t.CinemaRoom} ({t.MinimumAge}+)");

                priceString = messiReservation.TotalPrice.ToString("0.00");
                Console.WriteLine($"total price of reservation: {priceString}");
                Console.WriteLine();

                // Piet Paulusma

                t = new Ticket("Bohemian Rhapsody", 10.50);
                t.StartTime = DateTime.Parse("02/13/2021 21:30");
                t.CinemaRoom = 1;
                t.MinimumAge = 6;
                paulusmaReservation.Tickets.Add(t);
                startTimeString = t.StartTime.ToString("dd/MM/yyy HH:mm");
                priceString = t.Price.ToString("0.00");
                Console.WriteLine($"created ticket: '{t.MovieName}', start time: {startTimeString}, price: {priceString}, room: {t.CinemaRoom} ({t.MinimumAge}+)");

                t = new Ticket("The Prodigy", 10.50);
                t.StartTime = DateTime.Parse("02/13/2021 22:00");
                t.CinemaRoom = 4;
                t.MinimumAge = 16;
                paulusmaReservation.Tickets.Add(t);
                startTimeString = t.StartTime.ToString("dd/MM/yyy HH:mm");
                priceString = t.Price.ToString("0.00");
                Console.WriteLine($"created ticket: '{t.MovieName}', start time: {startTimeString}, price: {priceString}, room: {t.CinemaRoom} ({t.MinimumAge}+)");

                t = new Ticket("Green Book", 10.50);
                t.StartTime = DateTime.Parse("02/15/2021 19:00");
                t.CinemaRoom = 5;
                t.MinimumAge = 12;
                paulusmaReservation.Tickets.Add(t);
                startTimeString = t.StartTime.ToString("dd/MM/yyy HH:mm");
                priceString = t.Price.ToString("0.00");
                Console.WriteLine($"created ticket: '{t.MovieName}', start time: {startTimeString}, price: {priceString}, room: {t.CinemaRoom} ({t.MinimumAge}+)");

                priceString = paulusmaReservation.TotalPrice.ToString("0.00");
                Console.WriteLine($"total price of reservation: {priceString}");

            } catch (Exception ex)
            {
                Console.ResetColor();
                Console.WriteLine($"Error occured: {ex.Message}!");
            }
        }

        public void PrintCustomer(Customer customer)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(customer.Name);
            Console.ResetColor();
            string DoBString = customer.DateOfBirth.ToString("dd/MM/yyy");
            Console.WriteLine($"date of birth: {DoBString}");
            Console.WriteLine($"age: {customer.Age}");
            string discountString = customer.Discount ? "yes" : "no";
            Console.WriteLine($"discount: {discountString}");
            Console.WriteLine();
        }
    }

    internal class Customer
    {
        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentException("Empty name");
                }
                name = value;
            }
        }

        private DateTime dateOfBirth;

        public DateTime DateOfBirth
        {
            get { return dateOfBirth; }
            set
            {
                if (value > DateTime.Now)
                {
                    throw new ArgumentException("Date of birth must be in the past");
                }
                dateOfBirth = value;
            }
        }

        public int Age
        {
            get
            {
                return (int)Math.Floor((DateTime.Now - DateOfBirth).TotalDays / 365);
            }
        }

        public bool Discount
        {
            get
            {
                return Age >= 60;
            }
        }

        public Customer (string name, DateTime dateOfBirth)
        {
            Name = name;
            DateOfBirth = dateOfBirth;
        }
    }

    internal class Ticket
    {
        private string movieName;
        public string MovieName
        {
            get { return movieName; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentException("Empty movie name");
                }
                movieName = value;
            }
        }

        private int cinemaRoom;
        public int CinemaRoom
        {
            get { return cinemaRoom; }
            set
            {
                if (value < 1 || value > 5)
                {
                    throw new ArgumentException($"Invalid cinema room ({value})");
                }
                cinemaRoom = value;
            }
        }

        private DateTime startTime;
        public DateTime StartTime
        {
            get { return startTime; }
            set
            {
                if (value.Minute == 0 || value.Minute == 30)
                {
                    startTime = value;
                } else
                {
                    throw new ArgumentException($"Invalid start time ({value})");
                }
            }
        }

        public double Price
        {
            get; set;
        }

        private int minimumAge;
        public int MinimumAge
        {
            get { return minimumAge; }
            set
            {
                if (!new[] { 0, 6, 9, 12, 16}.Contains(value))
                {
                    throw new ArgumentException($"Invalid minimum age ({value})");
                }
                minimumAge = value;
            }
        }

        public bool Discount
        {
            get
            {
                if (StartTime.DayOfWeek == DayOfWeek.Monday || StartTime.DayOfWeek == DayOfWeek.Tuesday)
                {
                    return true;
                }
                return false;
            }
        }

        public Ticket (string movieName, double price )
        {
            MovieName = movieName;
            Price = price;
        }
    }

    internal class Reservation
    {
        public Customer Customer
        {
            get; set;
        }

        public List<Ticket> Tickets
        {
            get; set;
        }

        public double TotalPrice
        {
            get
            {
                double totalPrice = 0.00;
                foreach (Ticket ticket in Tickets)
                {
                    if (ticket.Discount)
                    {
                        totalPrice += ticket.Price * 0.95;
                    } else
                    {
                        totalPrice += ticket.Price;
                    }
                }
                if (Customer.Discount)
                {
                    totalPrice *= 0.9;
                }
                return totalPrice;
            }
        }

        public Reservation (Customer customer)
        {
            Customer = customer;
            Tickets = new List<Ticket>();
        }
    }
}
