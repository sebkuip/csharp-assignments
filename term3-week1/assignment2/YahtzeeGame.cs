namespace assignment2
{
    internal class YahtzeeGame
    {
        Dice[] dices = new Dice[5];

        public YahtzeeGame()
        {
            Random random = new Random();
            for (int i = 0; i < dices.Length; i++)
            {
                dices[i] = new Dice(random);
            }
        }

        public void Throw()
        {
            foreach (Dice dice in dices)
            {
                dice.Throw();
            }
        }

        public void DisplayValues()
        {
            foreach (Dice dice in dices)
            {
                dice.DisplayValue();
            }
            Console.WriteLine();
        }

        public bool Yahtzee()
        {
            int checkValue = dices[0].value;

            foreach (Dice dice in dices)
            {
                if (dice.value != checkValue)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
