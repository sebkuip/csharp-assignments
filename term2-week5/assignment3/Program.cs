namespace assignment3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Program myProgram = new Program();
            Dictionary<string, string> words = myProgram.ReadWords(args[0]);
            myProgram.TranslateWords(words);
        }

        Dictionary<string, string> ReadWords(string filename)
        {
            Dictionary<string, string> words = new Dictionary<string, string>();
            StreamReader sr = new StreamReader(filename);
            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                string[] splittedWords = line.Split(";");
                words[splittedWords[0]] = splittedWords[1];
            }

            return words;
        }

        void TranslateWords(Dictionary<string, string> words)
        {
            while (true)
            {
                Console.Write("Enter a word: ");
                string input = Console.ReadLine();
                if (input.Equals("stop"))
                {
                    return;
                } else if (input.Equals("listall"))
                {
                    this.ListAllWords(words);
                }
                if (!words.ContainsKey(input))
                {
                    Console.WriteLine($"word '{input}' not found");
                } else
                {
                    Console.WriteLine($"{input} => {words[input]}");
                }
            }
        }

        void ListAllWords(Dictionary<string, string> words)
        {
            foreach(KeyValuePair<string, string> pair in words)
            {
                Console.WriteLine($"{pair.Key} => {pair.Value}");
            }
        }
    }
}
