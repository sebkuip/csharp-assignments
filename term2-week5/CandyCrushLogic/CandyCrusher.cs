namespace CandyCrushLogic
{
    public class CandyCrusher
    {
        public static bool ScoreRowPresent(RegularCandies[,] playingField)
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

        public static bool ScoreColumnPresent(RegularCandies[,] playingField)
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
