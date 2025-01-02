namespace assignment3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Program myProgram = new Program();
            myProgram.Start();
        }

        enum RegularCandies
        {
            red = ConsoleColor.Red,
            orange = ConsoleColor.DarkYellow,
            yellow = ConsoleColor.Yellow,
            green = ConsoleColor.Green,
            blue = ConsoleColor.Blue,
            purple = ConsoleColor.Magenta,
        }

        void Start ()
        {
            RegularCandies[,] playingField = new RegularCandies[11,11];
            InitCandies(playingField);
            DisplayCandies(playingField);
            bool rowScore = ScoreRowPresent(playingField);
            bool columnScore = ScoreColumnPresent(playingField);

            Console.WriteLine();
            if (rowScore)
            {
                Console.WriteLine("row score");
            } else
            {
                Console.WriteLine("no row score");
            }

            if (columnScore)
            {
                Console.WriteLine("column score");
            } else
            {
                Console.WriteLine("no column score");
            }
        }

        void InitCandies(RegularCandies[,] playingField)
        {
            Array values = Enum.GetValues(typeof(RegularCandies));
            Random random = new Random(9);
            for (int i = 0; i < playingField.GetLength(0); i++)
            {
                for (int j = 0; j < playingField.GetLength(1); j++)
                {
                    playingField[i,j] = (RegularCandies)values.GetValue(random.Next(values.Length));
                }
            }
        }

        void DisplayCandies(RegularCandies[,] playingField)
        {
            for (int i = 0; i < playingField.GetLength(0); i++)
            {
                for (int j = 0; j < playingField.GetLength(1); j++)
                {
                    Console.ForegroundColor = (ConsoleColor)playingField[i,j];
                    Console.Write("# ");
                }
                Console.WriteLine();
            }
            Console.ResetColor();
        }

        bool ScoreRowPresent(RegularCandies[,] playingField)
        {
            for (int row = 0; row < playingField.GetLength(0); row++)
            {
                int counter = 1;
                RegularCandies currentCandy = playingField[row, 0];
                for (int column = 1; column < playingField.GetLength(1); column++)
                {
                    if (currentCandy.Equals(playingField[row, column]))
                    {
                        counter++;
                        if (counter == 3)
                        {
                            return true;
                        }
                    } else
                    {
                        counter = 1;
                        currentCandy = playingField[row, column];
                    }
                }
            }
            return false;
        }

        bool ScoreColumnPresent(RegularCandies[,] playingField)
        {
            for (int column = 0; column < playingField.GetLength(1); column++)
            {
                int counter = 1;
                RegularCandies currentCandy = playingField[0, column];
                for (int row = 1; row < playingField.GetLength(0); row++)
                {
                    if (currentCandy.Equals(playingField[row, column]))
                    {
                        counter++;
                        if (counter == 3)
                        {
                            return true;
                        }
                    }
                    else
                    {
                        counter = 1;
                        currentCandy = playingField[row, column];
                    }
                }
            }
            return false;
        }
    }
}
