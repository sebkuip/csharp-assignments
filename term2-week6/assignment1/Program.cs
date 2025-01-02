namespace assignment1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Program myProgram = new Program();
            myProgram.Start();
        }

        void Start()
        {
            ChessPiece[,] chessBoard = new ChessPiece[8, 8];
            InitChessboard(chessBoard);
            DisplayChessboard(chessBoard);
            PlayChess(chessBoard);
        }

        void InitChessboard(ChessPiece[,] chessboard)
        {
            for (int i = 0; i < chessboard.GetLength(0); i++)
            {
                for (int j = 0; j < chessboard.GetLength(1); j++)
                {
                    chessboard[i, j] = null;
                }
            }
            PutChessPieces(chessboard);
        }
        void PutChessPieces(ChessPiece[,] chessboard)
        {
            ChessPieceType[] order = { ChessPieceType.Rook, ChessPieceType.Knight, ChessPieceType.Bishop, ChessPieceType.Queen, ChessPieceType.King, ChessPieceType.Bishop, ChessPieceType.Knight, ChessPieceType.Rook };
            for (int i = 0; i < chessboard.GetLength(0); i++)
            {
                for (int j = 0; j < chessboard.GetLength(1); j++)
                {
                    if (i == 0)
                    {
                        // Black's backline
                        chessboard[i, j] = new ChessPiece(ChessPieceColor.Black, order[j]);
                    }
                    else if (i == 1)
                    {
                        // Black's pawns
                        chessboard[i, j] = new ChessPiece(ChessPieceColor.Black, ChessPieceType.Pawn);
                    }
                    else if (i == 6)
                    {
                        // White's pawns
                        chessboard[i, j] = new ChessPiece(ChessPieceColor.White, ChessPieceType.Pawn);
                    }
                    else if (i == 7)
                    {
                        // White's backline
                        chessboard[i, j] = new ChessPiece(ChessPieceColor.White, order[j]);
                    }
                }
            }
        }

        void DisplayChessboard(ChessPiece[,] chessboard)
        {
            for (int i = 0; i < chessboard.GetLength(0); i++)
            {
                Console.Write($"{8 - i} ");
                for (int j = 0; j < chessboard.GetLength(1); j++)
                {
                    if ((i + j) % 2 == 0)
                    {
                        Console.BackgroundColor = ConsoleColor.Gray;
                    } else
                    {
                        Console.BackgroundColor = ConsoleColor.DarkYellow;
                    }
                    Console.Write(DisplayChessPiece(chessboard[i, j]));
                    Console.ResetColor();
                }
                Console.WriteLine();
            }
            Console.WriteLine("   a  b  c  d  e  f  g  h");
        }

        string DisplayChessPiece(ChessPiece piece)
        {
            if (piece == null)
            {
                return "   ";
            }
            if (piece.color.Equals(ChessPieceColor.White))
            {
                Console.ForegroundColor = ConsoleColor.White;
            } else
            {
                Console.ForegroundColor = ConsoleColor.Black;
            }

            switch (piece.type)
            {
                case ChessPieceType.Pawn:
                    {
                        return " p ";
                    }
                case ChessPieceType.Rook:
                    {
                        return " r ";
                    }
                case ChessPieceType.Knight:
                    {
                        return " k ";
                    }
                case ChessPieceType.Bishop:
                    {
                        return " b ";
                    }
                case ChessPieceType.King:
                    {
                        return " K ";
                    }
                case ChessPieceType.Queen:
                    {
                        return " Q ";
                    }
                default:
                    {
                        return "   ";
                    }
            }
        }

        void PlayChess(ChessPiece[,] chessBoard)
        {
            while (true)
            {
                Console.WriteLine("Enter a move (e.g. a2 a3): ");
                string userInput = Console.ReadLine();
                if (userInput.Equals("stop"))
                {
                    break;
                }
                string[] splittedInput = userInput.Split(" ");
                if (splittedInput.Length != 2)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Invalid input: {userInput}");
                    Console.ResetColor();
                    continue;
                }
                try
                {
                    Position fromPosition = Position.String2Position(splittedInput[0]);
                    Position toPosition = Position.String2Position(splittedInput[1]);
                    DoMove(chessBoard, fromPosition, toPosition);
                } catch (Exception e)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(e.Message);
                    Console.ResetColor();
                    continue;
                }
                Console.WriteLine($"move from {splittedInput[0]} to {splittedInput[1]}");
                DisplayChessboard(chessBoard);
            }
        }

        void DoMove(ChessPiece[,] board, Position from, Position to)
        {
            CheckMove(board, from, to);
            board[to.row, to.column] = board[from.row, from.column];
            board[from.row, from.column] = null;
        }

        void CheckMove(ChessPiece[,] board, Position from, Position to)
        {
            int hor = Math.Abs(from.row - to.row);
            int ver = Math.Abs(from.column - to.column);
            if (hor == 0 && ver == 0)
            {
                throw new Exception("No movement");
            } else if (board[from.row, from.column] == null)
            {
                throw new Exception("No chess piece at from-position");
            } else if (board[to.row, to.column] != null)
            {
                if (board[from.row, from.column].color.Equals(board[to.row, to.column].color))
                {
                    throw new Exception("Can not take a chess piece of same color");
                }
            }
            switch (board[from.row, from.column].type)
            {
                case ChessPieceType.Pawn:
                    {
                        bool firstMove = false;
                        if (board[from.row, from.column].color == ChessPieceColor.White && from.row == 6)
                        {
                            firstMove = true;
                        } else if (board[from.row, from.column].color == ChessPieceColor.Black && from.row == 1)
                        {
                            firstMove = true;
                        }
                        if (!(hor != 0 && ver != 1) || !(firstMove && hor != 0 && ver !=2))
                        {
                            throw new Exception("Invalid move for chess piece Pawn");
                        }
                        break;
                    }
                case ChessPieceType.Rook:
                    {
                        if (hor * ver != 0)
                        {
                            throw new Exception("Invalid move for chess piece Rook");
                        }
                        break;
                    }
                case ChessPieceType.Knight:
                    {
                        if (hor * ver != 2)
                        {
                            throw new Exception("Invalid move for chess piece Knight");
                        }
                        break;
                    }
                case ChessPieceType.Bishop:
                    {
                        if (hor != ver)
                        {
                            throw new Exception("Invalid move for chess piece Bishop");
                        }
                        break;
                    }
                case ChessPieceType.King:
                    {
                        if (hor != 1 || ver != 1)
                        {
                            throw new Exception("Invalid move for chess piece King");
                        }
                        break;
                    }
                case ChessPieceType.Queen:
                    {
                        if (hor * ver != 0 || hor != ver)
                        {
                            throw new Exception("Invalid move for chess piece Queen");
                        }
                        break;
                    }
            }
        }
    }
}
