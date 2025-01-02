namespace assignment1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Program myProgram = new Program();
            myProgram.PrintMonths();
            Month month = myProgram.ReadMonth("Enter a number: ");
            myProgram.PrintMonth(month);
        }

        void PrintMonth(Month month)
        {
            Console.WriteLine((int)month + " => " + month.ToString());
        }

        void PrintMonths()
        {
            foreach (Month month in Enum.GetValues(typeof(Month)))
            {
                PrintMonth(month);
            }
        }

        Month ReadMonth(string question)
        {
            bool valid = false;
            Month month = Month.January;

            while (!valid)
            {
                Console.Write("Enter a month number: ");
                string input = Console.ReadLine();
                int monthNumber = int.Parse(input);

                if (Enum.IsDefined(typeof(Month), monthNumber))
                {
                    valid = true;
                    month = (Month)monthNumber;
                } else
                {
                    Console.WriteLine($"{monthNumber} is not a valid value");
                }
            }
            return month;
        }
    }
}