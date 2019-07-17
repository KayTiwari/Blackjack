namespace blackjack
{
    using System;

    //Represents the suit of a card
    public enum CardSuit
    {
        Unknown = 0,
        //Unknown Card suit

        Heart = 1,
        Club = 2,
        Spade = 3,
        Diamond = 4
    }

    /// Contains information about a playing card. ///
    public class Card
    {

        //Initializes a new instance of the Card class
        public Card(CardSuit suit, int rank)
        {
            this.Suit = suit;
            this.Rank = rank;
        }
        // Gets or Sets values of playing card rank
        public int Rank
        {
            get; private set;
        }

        //Gets or Sets suit of the card
        public CardSuit Suit { get; private set; }


        //Returns a true value if card suit is red or false if black
        public bool IsRed
        {
            get
            {
                return this.Suit == CardSuit.Heart || this.Suit == CardSuit.Diamond;
            }
        }

        public void PrintCardToScreen()
        {
            Console.WriteLine($"Suit: {this.Suit}, Rank: {this.Rank}");
        }
    }
}

