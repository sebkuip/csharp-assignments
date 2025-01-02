namespace assignment2
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

        Person ReadPerson()
        {
            Person myPerson = new Person();
            myPerson.FirstName = ReadString("Enter first name: ");
            myPerson.LastName = ReadString("Enter last name: ");
            myPerson.Gender = ReadGender("Enter gender: ");
            myPerson.Age = ReadInt("Enter age: ");
            myPerson.City = ReadString("Enter city: ");

            return myPerson;
        }

        GenderType ReadGender(string question)
        {
            string genderString = ReadString(question);
            if (genderString.Equals("m")) {
                return GenderType.Male;
            } else
            {
                return GenderType.Female;
            }
        }

        void PrintGender(GenderType myGender)
        {
            if (myGender == GenderType.Male)
            {
                Console.Write("(m)");
            } else
            {
                Console.Write("(f)");
            }
        }

        void PrintPerson(Person person)
        {
            Console.Write($"{person.FirstName} {person.LastName} ");
            PrintGender(person.Gender);
            Console.WriteLine();
            Console.WriteLine($"{person.Age} years old, {person.City}");
        }

        static void Main(string[] args)
        {
            Program myProgram = new Program();
            Person[] persons = new Person[3];
            
            for (int i = 0; i < persons.Length; i++)
            {
                persons[i] = myProgram.ReadPerson();
                Console.WriteLine();
            }
            Console.WriteLine();

            for (int i = 0;i < persons.Length; i++)
            {
                myProgram.PrintPerson(persons[i]);
                Console.WriteLine();
            }
        }
    }
}