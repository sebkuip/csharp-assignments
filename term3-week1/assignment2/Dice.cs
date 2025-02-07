namespace assignment2
{
    internal class Dice
    {
        public int value;
        private Random random;

        public Dice (Random random)
        {
            this.random = random;
        }

        public void Throw()
        {
            value = random.Next(1, 7);
        }

        public void DisplayValue()
        {
            Console.Write(value.ToString() + " ");
        }
    }
}
