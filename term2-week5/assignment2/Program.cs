namespace assignment2
{
    using CandyCrushLogic;
    internal class Program
    {
        static void Main(string[] args)
        {
            Program myProgram = new Program();
            myProgram.Start();
        }

        void Start()
        {
            RegularCandies[,] playingField = new RegularCandies[11, 11];
            InitCandies(playingField);
            DisplayCandies(playingField);
            bool rowScore = CandyCrusher.ScoreRowPresent(playingField);
            bool columnScore = CandyCrusher.ScoreColumnPresent(playingField);

            Console.WriteLine();
            if (rowScore)
            {
                Console.WriteLine("row score");
            }
            else
            {
                Console.WriteLine("no row score");
            }

            if (columnScore)
            {
                Console.WriteLine("column score");
            }
            else
            {
                Console.WriteLine("no column score");
            }
        }

        void InitCandies(RegularCandies[,] playingField)
        {
            Array values = Enum.GetValues(typeof(RegularCandies));
            Random random = new Random();
            for (int i = 0; i < playingField.GetLength(0); i++)
            {
                for (int j = 0; j < playingField.GetLength(1); j++)
                {
                    playingField[i, j] = (RegularCandies)values.GetValue(random.Next(values.Length));
                }
            }
        }

        void DisplayCandies(RegularCandies[,] playingField)
        {
            for (int i = 0; i < playingField.GetLength(0); i++)
            {
                for (int j = 0; j < playingField.GetLength(1); j++)
                {
                    Console.ForegroundColor = (ConsoleColor)playingField[i, j];
                    Console.Write("# ");
                }
                Console.WriteLine();
            }
            Console.ResetColor();
        }
    }
}
