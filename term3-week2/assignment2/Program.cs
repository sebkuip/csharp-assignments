namespace assignment2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Program myProgram = new Program();
            myProgram.Start(args);
        }

        void Start(string[] args)
        {
            DeckOfCards deck = new DeckOfCards();
            deck.Print();

            deck.Shuffle();
            deck.Print();
        }

        internal enum CardSuit
        {
            Spades,
            Clubs,
            Hearts,
            Diamonds
        }

        internal class PlayingCard
        {
            public CardSuit suit;
            public string rank;

            public PlayingCard(CardSuit suit, string rank)
            {
                this.suit = suit;
                this.rank = rank;
            }

            public override string ToString()
            {
                return $"{rank} of {suit}";
            }
        }

        internal class DeckOfCards
        {
            public List<PlayingCard> allPlayingCards = new List<PlayingCard>();

            public DeckOfCards()
            {
                InitCards();
            }

            private void InitCards()
            {
                string[] ranks = new string[] { "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King", "Ace" };

                foreach (CardSuit suit in Enum.GetValues(typeof(CardSuit)))
                {
                    foreach (string rank in ranks)
                    {
                        PlayingCard card = new PlayingCard(suit, rank);
                        allPlayingCards.Add(card);
                    }
                }
            }

            public void Shuffle()
            {
                Random random = new Random(1);
                int count = allPlayingCards.Count;
                for(int i = 0; i < 100; i++)
                {
                    int index1 = random.Next(count);
                    int index2 = random.Next(count);

                    PlayingCard tmpCard = allPlayingCards[index1];
                    allPlayingCards[index1] = allPlayingCards[index2];
                    allPlayingCards[index2] = tmpCard;
                }
            }

            public void Print()
            {
                foreach(PlayingCard card in allPlayingCards)
                {
                    Console.WriteLine(card);
                }
            }
        }
    }
}
