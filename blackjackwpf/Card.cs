using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    public enum Suit
    {
        Unknown = 0,
        Hearts = 1,
        Clubs = 2,
        Spades = 3,
        Diamonds = 4
    };
    public class Card
    {

        public Card(Suit suit, int rank)
        {
            this.Suit = suit;
            this.Rank = rank;
        }

        public Suit Suit { get; private set; }
        public int Rank { get; private set; }
    }
}
