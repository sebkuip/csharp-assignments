namespace assignment2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 2)
            {
                Console.WriteLine("Invalid number of arguments!");
                Console.WriteLine("usage: assignment[1-3] <nr of rows> <nr of columns>");
                return;
            }

            int numberOfRows = int.Parse(args[0]);
            int numberOfColumns = int.Parse(args[1]);

            Program myProgram = new Program();
            myProgram.Start(numberOfRows, numberOfColumns);
        }

        void Start(int numberOfRows, int numberOfColumns)
        {
            int[,] matrix = new int[numberOfRows, numberOfColumns];
            InitMatrixRandom(matrix, 1, 100);
            DisplayMatrix(matrix);

            Console.Write("Enter a number (to search for): ");
            int searchValue = int.Parse(Console.ReadLine());

            Position pos1 = SearchNumber(matrix, searchValue);
            Position pos2 = SearchNumberBackwards(matrix, searchValue);

            Console.WriteLine($"Number {searchValue} is found (first) at position [{pos1.column},{pos1.row}]");
            Console.WriteLine($"Number {searchValue} is found (last) at position [{pos2.column},{pos2.row}]");
        }

        void InitMatrixRandom(int[,] matrix, int min, int max) {
            Random random = new Random();
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = random.Next(min, max);
                }
            }
        }

        void DisplayMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        Position SearchNumber(int[,] matrix, int number)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == number)
                    {
                        Position position = new Position();
                        position.row = j;
                        position.column = i;
                        return position;
                    }
                }
            }
            Position pos = new Position();
            pos.row = -1;
            pos.column = -1;
            return pos;
        }

        Position SearchNumberBackwards(int[,] matrix, int number)
        {
            for (int i = matrix.GetLength(0) - 1; i >= 0; i--)
            {
                for (int j = matrix.GetLength(1) - 1; j >= 0; j--)
                {
                    if (matrix[i, j] == number)
                    {
                        Position position = new Position();
                        position.row = j;
                        position.column = i;
                        return position;
                    }
                }
            }
            Position pos = new Position();
            pos.row = -1;
            pos.column = -1;
            return pos;
        }
    }

    class Position
    {
        public int row;
        public int column;
    }
}