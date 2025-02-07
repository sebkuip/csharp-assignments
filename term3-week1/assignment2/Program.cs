namespace assignment2
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
            YahtzeeGame yahtzeeGame = new YahtzeeGame();
            PlayYahtzee(yahtzeeGame);
        }

        void PlayYahtzee(YahtzeeGame game)
        {
            int nrOfAttempts = 0;

            do
            {
                game.Throw();
                game.DisplayValues();

                nrOfAttempts++;
            } while (!game.Yahtzee());

            Console.WriteLine($"Number of attempts needed (for Yahtzee): {nrOfAttempts}");
        }
    }
}
