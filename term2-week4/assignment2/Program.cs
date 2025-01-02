﻿namespace assignment2
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
            HangmanGame hangman = new HangmanGame();
            List<string> words = ListOfWords(filename);
            string secretWord = SelectWord(words);
            hangman.Init(secretWord);
            bool win = PlayHangman(hangman);
            Console.WriteLine();
            if (win)
            {
                Console.WriteLine("You guessed the word!");
            }
            else
            {
                Console.WriteLine($"Too bad, you did not guess the word ({hangman.secretWord})");
            }
        }

        string SelectWord(List<string> words)
        {
            Random random = new Random();
            string word = "";
            do
            {
                word = words[random.Next(words.Count)];
            } while (word.Length < 3);
            return word;
        }

        public List<string> ListOfWords(string filename)
        {
            List<string> words = new List<string>();
            StreamReader reader = new StreamReader(filename);
            while (!reader.EndOfStream)
            {
                words.Add(reader.ReadLine());
            }
            return words;
        }

        bool PlayHangman(HangmanGame hangman)
        {
            List<char> enteredLetters = new List<char>();
            DisplayWord(hangman.guessedWord);
            for (int i = 7; i >= 0; i--)
            {
                Console.WriteLine();
                char c = ReadLetter(enteredLetters);
                enteredLetters.Add(c);
                if (hangman.ContainsLetter(c))
                {
                    hangman.ProcessLetter(c);
                    i++;
                }
                DisplayLetters(enteredLetters);
                Console.WriteLine($"Attempts left: {i}");
                Console.WriteLine();
                DisplayWord(hangman.guessedWord);

                if (hangman.IsGuessed())
                {
                    return true;
                }
            }
            return false;
        }

        void DisplayWord(string word)
        {
            foreach (char c in word)
            {
                Console.Write(c + " ");
            }
            Console.WriteLine();
        }

        void DisplayLetters(List<char> letters)
        {
            Console.Write("Entered letters: ");
            foreach (char c in letters)
            {
                Console.Write(c + " ");
            }
            Console.WriteLine();
        }

        char ReadLetter(List<char> blacklistedLetters)
        {
            char c;
            do
            {
                Console.Write("Enter a letter: ");
                c = Console.ReadLine()[0];
            } while (blacklistedLetters.Contains(c));
            return c;
        }
    }

    class HangmanGame
    {
        public string secretWord;
        public string guessedWord;

        public void Init(string secretWord)
        {
            this.secretWord = secretWord;
            this.guessedWord = new string('.', secretWord.Length);
        }

        public bool ContainsLetter(char letter)
        {
            return secretWord.Contains(letter);
        }

        public void ProcessLetter(char letter)
        {
            List<int> indices = new List<int>();
            for (int i = secretWord.IndexOf(letter); i > -1; i = secretWord.IndexOf(letter, i + 1))
            {
                indices.Add(i);
            }
            System.Text.StringBuilder sb = new System.Text.StringBuilder(guessedWord);
            foreach (int i in indices)
            {
                sb[i] = letter;
            }
            guessedWord = sb.ToString();
        }

        public bool IsGuessed()
        {
            return guessedWord.Equals(secretWord);
        }
    }
}
