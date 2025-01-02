using static assignment4.LingoGame;

namespace assignment4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Program myProgram = new Program();
            myProgram.Start(args[0]);
        }

        public void Start(string filename)
        {
            List<string> words = ReadWords(filename, 5);
            string lingoWord = SelectWord(words);

            LingoGame lingoGame = new LingoGame();
            lingoGame.Init(lingoWord);
            if (PlayLingo(lingoGame))
            {
                Console.WriteLine("You have guessed the word!");
            } else
            {
                Console.WriteLine($"Too bad, you did not guess the word ({lingoWord})");
            }
        }

        public List<string> ReadWords(string filename, int wordLength)
        {
            StreamReader sr = new StreamReader(filename);
            List<string> words = new List<string>();

            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                if (line.Length == wordLength)
                {
                    words.Add(line);
                }
            }
            sr.Close();
            return words;
        }

        public string SelectWord(List<string> words)
        {
            Random random = new Random();
            return words[random.Next(words.Count)];
        }

        public bool PlayLingo(LingoGame lingoGame)
        {
            int attemptsLeft = 5;
            int wordLength = lingoGame.lingoWord.Length;

            while (attemptsLeft > 0 && !lingoGame.WordGuessed())
            {
                Console.Write($"Enter a ({wordLength}-letter) word, attempt {6 - attemptsLeft}: ");
                string playerWord = ReadPlayerWord(wordLength);
                LetterState[] letterResults = lingoGame.ProcessWord(playerWord);
                DisplayPlayerWord(playerWord, letterResults);

                attemptsLeft -= 1;
            }

            return lingoGame.WordGuessed();
        }

        public string ReadPlayerWord(int length)
        {
            string word;
            do
            {
                word = Console.ReadLine(); 
            } while (word.Length != length);
            return word.ToUpper();
        }

        public void DisplayPlayerWord(string playerWord, LetterState[] letterResults)
        {
            for (int i = 0; i < playerWord.Length; i++)
            {
                if (letterResults[i] == LetterState.Correct)
                {
                    Console.BackgroundColor = ConsoleColor.DarkGreen;
                } else if (letterResults[i] == LetterState.WrongPosition)
                {
                    Console.BackgroundColor = ConsoleColor.DarkYellow;
                }

                Console.Write(playerWord[i]);
                Console.ResetColor();
            }
            Console.WriteLine();
        }
    }
}
