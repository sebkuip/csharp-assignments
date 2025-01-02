namespace assignment1
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
            string name = ReadString("Enter your name: ");
            if (File.Exists($"{name}.txt".ToLower()))
            {
                Console.WriteLine($"Nice to see you again, {name}!");
                Console.WriteLine("We have the following information about you:");
                Person p = ReadPerson($"{name}.txt".ToLower());
                DisplayPerson(p);
            } else
            {
                Console.WriteLine($"Welcome {name}!");
                Person p = ReadPerson();
                WritePerson(p, $"{name}.txt".ToLower());
                Console.WriteLine("Your data is written to file");
            }
        }

        Person ReadPerson()
        {
            string name = ReadString("Enter your name: ");
            string city = ReadString("Enter your city: ");
            int age = ReadInt("Enter your age: ", 0, 100);
            Person myPerson = new Person();
            myPerson.name = name;
            myPerson.city = city;
            myPerson.age = age;
            return myPerson;
        }

        Person ReadPerson(string filename)
        {
            StreamReader reader = new StreamReader(filename.ToLower());
            Person myPerson = new Person();
            myPerson.name = reader.ReadLine();
            myPerson.city = reader.ReadLine();
            myPerson.age = int.Parse(reader.ReadLine());
            return myPerson;
        }

        void DisplayPerson(Person p)
        {
            Console.WriteLine($"Name: {p.name}");
            Console.WriteLine($"City: {p.city}");
            Console.WriteLine($"Age: {p.age}");
        }

        void WritePerson(Person p, string filename)
        {
            StreamWriter writer = new StreamWriter(filename.ToLower());
            writer.WriteLine(p.name);
            writer.WriteLine(p.city);
            writer.WriteLine(p.age);
            writer.Close();
        }

    }
}
