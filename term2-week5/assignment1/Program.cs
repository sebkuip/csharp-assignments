namespace assignment1
{
    using MyTools;
    internal class Program
    {
        static void Main(string[] args)
        {
            Program myProgram = new Program();
            myProgram.Start();
        }

        void Start()
        {
            int value = ReadTools.ReadInt("Enter a value: ");
            Console.WriteLine($"You entered {value}");

            int age = ReadTools.ReadInt("How old are you? ", 0, 120);
            Console.WriteLine($"You are {age} years old.");

            string name = ReadTools.ReadString("What is your name? ");
            Console.WriteLine($"Nice meeting you {name}");
        }
    }
}
