namespace term2_week1
{
    internal class Program
    {
        int ReadInt(string question)
        {
            Console.Write(question);
            string input = Console.ReadLine();
            return int.Parse(input);
        }

        int ReadInt(string question, int minValue, int maxValue)
        {
            bool valid = false;
            int input = 0;
            while (!valid)
            {
                input = ReadInt(question);
                if (minValue <= input && input <= maxValue)
                {
                    valid = true;
                }
            }
            return input;
        }

        string ReadString(string question)
        {
            Console.Write(question);
            return Console.ReadLine();
        }

        static void Main(string[] args)
        {
            Program myProgram = new Program();
            myProgram.Start();
        }

        void Start()
        {
            int value = ReadInt("Enter a value: ");
            Console.WriteLine($"You entered {value}");

            int age = ReadInt("How old are you? ", 0, 120);
            Console.WriteLine($"You are {age} years old.");

            string name = ReadString("What is your name? ");
            Console.WriteLine($"Nice meeting you {name}");
        }
    }
}