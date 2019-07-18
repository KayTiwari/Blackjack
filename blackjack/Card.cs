namespace blackjack
{
    using System;

    //Represents the suit of a card
    public enum CardSuit
    {
        Unknown = 0,
        //Unknown Card suit

        Hearts = 1,
        Clubs = 2,
        Spades = 3,
        Diamonds = 4
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
                return this.Suit == CardSuit.Hearts || this.Suit == CardSuit.Diamonds;
            }
        }

        public void PrintCardToScreen()
        {
            Console.WriteLine($"{this.Rank} of {this.Suit}");
        }
    }
}

