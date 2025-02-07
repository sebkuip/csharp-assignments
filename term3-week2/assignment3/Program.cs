namespace assignment3
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
            Player player1 = new Player("John");
            Player player2 = new Player("Emma");

            WarCardGame war = new WarCardGame(player1, player2);
            PlayTheGame(war);
        }

        void PlayTheGame(WarCardGame war)
        {
            war.StartNewGame();
            while (!war.EndOfGame())
            {
                war.NextCard();
            }

            if (war.player1.cards.Count == 0 || war.player2.cards.Count != 0)
            {
                Console.WriteLine($"\n{war.player2.name} has won!");
            } else if (war.player1.cards.Count != 0 || war.player2.cards.Count == 0)
            {
                Console.WriteLine($"\n{war.player1.name} has won!");
            } else
            {
                Console.WriteLine("\nDraw");
            }
        }

        internal class Player
        {
            public string name;
            public List<PlayingCard> cards;

            public Player(string name)
            {
                this.name = name;
                this.cards = new List<PlayingCard>();
            }

            public void AddCard(PlayingCard card)
            {
                cards.Add(card);
            }

            public PlayingCard GetNextCard()
            {
                PlayingCard card = cards.First();
                cards.RemoveAt(0);
                return card;
            }
        }

        internal class CardGame
        {
            public List<PlayingCard> cards = new List<PlayingCard>();
        }

        internal class WarCardGame : CardGame
        {
            public Player player1;
            public Player player2;

            public WarCardGame(Player player1, Player player2)
            {
                this.player1 = player1;
                this.player2 = player2;
            }

            public void StartNewGame()
            {
                DeckOfCards deck = new DeckOfCards();
                deck.Shuffle();

                Player shuffleTurn = player1;
                foreach(PlayingCard card in deck.allPlayingCards)
                {
                    if (shuffleTurn == player1)
                    {
                        player1.AddCard(card);
                        shuffleTurn = player2;
                    } else
                    {
                        player2.AddCard(card);
                        shuffleTurn = player1;
                    }
                }
            }

            public bool EndOfGame()
            {
                if(player1.cards.Count <= 0 || player2.cards.Count <= 0)
                {
                    return true;
                } else
                {
                    return false;
                }
            }

            public void NextCard()
            {
                string[] ranks = new string[] { "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King", "Ace" };

                PlayingCard p1Card = player1.GetNextCard();
                PlayingCard p2Card = player2.GetNextCard();

                Console.WriteLine($"[{player1.name}] {p1Card} - [{player2.name}] {p2Card}");

                int p1Index = Array.IndexOf(ranks, p1Card.rank);
                int p2Index = Array.IndexOf(ranks, p2Card.rank);

                if (p1Index > p2Index)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"{player1.name} got the cards");

                    player1.AddCard(p1Card);
                    player1.AddCard(p2Card);
                }
                else if (p1Index < p2Index)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"{player2.name} got the cards");

                    player2.AddCard(p2Card);
                    player2.AddCard(p1Card);
                } else
                {
                    Console.ForegroundColor= ConsoleColor.Red;
                    Console.WriteLine($"2 cards lost...\ncards left: [{player1.name}] {player1.cards.Count}x, [{player2.name}] {player2.cards.Count}x");
                }
                Console.ResetColor();
            }
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
                Random random = new Random(2);
                int count = allPlayingCards.Count;
                for (int i = 0; i < 100; i++)
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
                foreach (PlayingCard card in allPlayingCards)
                {
                    Console.WriteLine(card);
                }
            }
        }
    }
}
