
namespace blackjack
{
using System;
    using System.Collections.Generic;

    public class Program
    {
        public List<Card> deck = new List<Card>();  
        public static List<Card> shuffleddeck = new List<Card>();  

  
        //Main blackjack program  -- entry point
        public static void Main(string[] args)
        {
            Program game = new Program();
            game.StartGame();
        }

        public void StartGame()
        {
            deck.Clear();
            for (int s = 1; s < 5; s++)
            {
                CardSuit suit = (CardSuit)s;
                for (int r = 1; r < 14; r++){
                    Card card = new Card(suit, r);
                    deck.Add(card);
                }
            }
            Shuffle(deck);
        }
        //Method to shuffle cards in deck
        public static void Shuffle(List<Card> deck)
        {
            
            Random rng = new Random();
            int count = deck.Count;
            while (count > 1)
            {
                count--;
                int k = rng.Next(count + 1);
                Card card = deck[k];
                deck[k] = deck[count];
                deck[count] = card;
                shuffleddeck.Add(card);
            }
            Console.WriteLine("Let's start the game!");
            Game game = new Game();
            game.StartGame(shuffleddeck);
            
        }
    }
}
