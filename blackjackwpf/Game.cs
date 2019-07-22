using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    public class Game
    {
        public ObservableCollection<Card> Deck;
        public ObservableCollection<Card> ShuffledDeck = new ObservableCollection<Card>();

        public ObservableCollection<Card> YourHand = new ObservableCollection<Card>();
        public ObservableCollection<Card> DealerHand = new ObservableCollection<Card>();

        public Game()
        {
            this.Deck = new ObservableCollection<Card>();
        }
        public void renderCard()
        {
            for (var i = 1; i < 5; i++)
            {
                Suit suit = (Suit)i;
                for (var k = 1; k < 14; k++)
                {
                    Card card = new Card(suit, k);
                    Deck.Add(card);
                }
            }
            Shuffle();
        }

        private void Shuffle()
        {
            Random rng = new Random();
            int count = Deck.Count;
            while (count > 1)
            {
                count--;
                int k = rng.Next(count + 1);
                Card card = Deck[k];
                Deck[k] = Deck[count];
                Deck[count] = card;
                ShuffledDeck.Add(card);
            }
        }
 
    }
}
