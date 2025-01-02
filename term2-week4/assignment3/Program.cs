namespace assignment3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine("Invalid number of arguments!");
                Console.WriteLine("usage: assignment[2-3] <filename>");
                return;
            }

            string filename = args[0];

            Program myProgram = new Program();
            myProgram.Start(filename);
        }

        void Start(string filename)
        {
            Console.Write("Enter a word to search: ");
            string word = Console.ReadLine();
            Console.WriteLine();
            int count = WordInFile(filename, word);
            Console.WriteLine($"Number of lines containing the word: {count}");
        }

        bool WordInLine(string line, string word)
        {
            return line.ToLower().Contains(word.ToLower());
        }

        int WordInFile(string filename, string word)
        {
            int count = 0;
            StreamReader reader = new StreamReader(filename);
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                if (WordInLine(line, word))
                {
                    count++;
                    DisplayWordInLine(line, word);
                }
            }
            return count;
        }

        void DisplayWordInLine(string line, string word)
        {
            int index = line.ToLower().IndexOf(word.ToLower());
            string startOfLine = line.Substring(0, index);
            string wordInLine = line.Substring(index, word.Length);
            string endOfLine = line.Substring(index + word.Length);

            Console.Write(startOfLine);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write($"[{wordInLine}]");
            Console.ResetColor();
            Console.Write(endOfLine + "\n\n");
        }
    }
}
