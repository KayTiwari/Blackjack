
namespace blackjack
{
using System;
    using System.Collections.Generic;

    public class Program
    {
        //Main blackjack program  -- entry point
        public static void Main(string[] args)
        {
            List<Card> deck = new List<Card>();
            for (int s = 1; s < 5; s++)
            {
                CardSuit suit = (CardSuit)s;
                for (int r = 1; r < 14; r++){
                    Card card = new Card(suit, r);
                    deck.Add(card);
                }
            }
            foreach(Card card in deck){
                card.PrintCardToScreen();
            }
        }
    }
}
