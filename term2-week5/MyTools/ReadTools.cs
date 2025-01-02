using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTools
{
    public class ReadTools
    {
        public static int ReadInt(string question)
        {
            Console.Write(question);
            string input = Console.ReadLine();
            return int.Parse(input);
        }

        public static int ReadInt(string question, int minValue, int maxValue)
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

        public static string ReadString(string question)
        {
            Console.Write(question);
            return Console.ReadLine();
        }
    }
}
