namespace assignment3
{
    internal class Dice
    {
        public int value;
        private Random random = new Random();
        
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
