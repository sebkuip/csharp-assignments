namespace assignment1
{
    public class Position
    {
        public int row;
        public int column;

        public Position(int row, int column)
        {
            this.row = row;
            this.column = column;
        }

        public static Position String2Position(string pos)
        {
            try
            {
                int column = pos[0] - 'a';
                int row = 8 - int.Parse(pos[1].ToString());
                if (column < 0 || column > 7 || row < 0 || row > 7)
                {
                    throw new Exception($"Invalid position {pos}");
                }
                return new Position(row, column);
            } catch
            {
                throw new Exception($"Invalid position {pos}");
            }
        }
    }
}
