namespace assignment4
{
    internal class LingoGame
    {
        public enum LetterState
        {
            Correct,
            Incorrect,
            WrongPosition,
        }

        public string lingoWord;
        public string playerWord;

        public void Init(string lingoWord)
        {
            this.lingoWord = lingoWord;
            this.playerWord = "";
        }

        public bool WordGuessed()
        {
            return this.lingoWord.Equals(this.playerWord);
        }

        public LetterState[] ProcessWord(string playerWord)
        {
            this.playerWord = playerWord;
            LetterState[] letterResults = new LetterState[this.lingoWord.Length];

            List<char> refLetters = new List<char>();
            for (int i = 0; i < this.lingoWord.Length; i++)
            {
                if (this.lingoWord.Contains(playerWord[i]))
                {
                    refLetters.Add(this.playerWord[i]);
                }
            }
            for (int i = 0; i < this.lingoWord.Length; i++)
            {
                if (this.lingoWord[i].Equals(this.playerWord[i]))
                {
                    letterResults[i] = LetterState.Correct;
                }
                else
                {
                    if (refLetters.Contains(this.playerWord[i]))
                    {
                        letterResults[i] = LetterState.WrongPosition;
                        refLetters.Remove(this.playerWord[i]);
                    }
                    else
                    {
                        letterResults[i] = LetterState.Incorrect;
                    }
                }
            }
            return letterResults;
        }
    }
}
