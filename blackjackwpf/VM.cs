using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Blackjack
{
    public class VM : BaseVM
    {
        
        public ObservableCollection<Card> ShuffledDeck { get; private set; }
        Game game = new Game();

        private ObservableCollection<Card> yourhand = new ObservableCollection<Card>();
        private ObservableCollection<Card> dealerhand = new ObservableCollection<Card>();
        private int currentCount;
        private bool didStand;

        private int yourscore;
        private int dealerscore;


        public VM()
        {
            game.renderCard();
            this.ShuffledDeck = game.ShuffledDeck;
            this.startGame();
            this.YourHand.CollectionChanged += (s, args) =>
            {
                if (args.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
                {
                    CommandManager.InvalidateRequerySuggested();
                }
            };
            this.DealerHand.CollectionChanged += (s, args) =>
            {
                if (args.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
                {
                    CommandManager.InvalidateRequerySuggested();
                }
            };
            this.AddCardCommand = new SimpleCommand((obj) => true,
                (obj) =>
                {
                    YourHand.Add(ShuffledDeck[currentCount]);
                    this.currentCount++;
                    HandCheck(this.currentCount);
                }
                );
            this.StandCommand = new SimpleCommand((obj) => true,
                (obj) =>
                {
                    didStand = true;
                    Stand();
                }
                );
        }


        private void startGame()
        {
            int number = 4;
            this.currentCount = number;
            MainGame(number);
        }

        private void MainGame(int count)
        {
            for (var i = 1; i < count; i++)
            {
                if (i % 2 == 1)
                {
                    yourhand.Add(ShuffledDeck[i]);
                }
                else
                {
                    DealerHand.Add(ShuffledDeck[i]);
                }
            }
            foreach (Card card in YourHand)
            {
                Console.WriteLine(card.Rank); 
                if (card.Rank == 1 || card.Rank == 10 || card.Rank == 11 || card.Rank == 12 || card.Rank == 13)
                {
                    YourScore += 10;
                }
                else
                {
                    YourScore += card.Rank;
                }
            }
            foreach (Card card in DealerHand)
            {
                if (card.Rank == 1 || card.Rank == 10 || card.Rank == 11 || card.Rank == 12 || card.Rank == 13)
                {
                    DealerScore += 10;
                }
                else
                {
                    DealerScore += card.Rank;
                }
            }
            this.currentCount = count;
        }

        private void HandCheck(int count)
        {
            Console.WriteLine("fired");
            int cardValue = 0;
            int dealerCardValue = 0;
            foreach(Card card in YourHand)
            {
                if (card.Rank == 1 || card.Rank == 10 || card.Rank == 11 || card.Rank == 12 || card.Rank == 13)
                {
                    cardValue += 10;
                }
                else
                {
                cardValue += card.Rank;
                }
                YourScore = cardValue;
                OnNotify();
            }
            foreach (Card card in DealerHand)
            {
                if (card.Rank == 1 || card.Rank == 10 || card.Rank == 11 || card.Rank == 12 || card.Rank == 13)
                {
                    dealerCardValue += 10;
                }
                else
                {
                    dealerCardValue += card.Rank;
                }
                DealerScore = dealerCardValue;
                OnNotify();
            }

            if (YourScore > 21 || DealerScore > 21)
            {
                foreach (Card card in YourHand)
                {
                    if (YourScore > 21 && card.Rank == 1)
                    {
                        YourScore -= 10;
                        OnNotify();
                    }
                }
                foreach (Card card in DealerHand)
                {
                    if (DealerScore > 21 && card.Rank == 1)
                    {
                        DealerScore -= 10;
                        OnNotify();
                    }
                }
                if (YourScore > 21 && DealerScore > 21)
                {
                    GameLose();
                }
                else if (YourScore > 21)
                {
                    GameLose();
                }
                else if (DealerScore > 21)
                {
                    GameWin();
                }
            }
            if (YourScore == 21 || DealerScore == 21)
            {
                if (YourScore == 21 && DealerScore == 21)
                {
                    Tie();
                }
                else if (YourScore == 21)
                {
                    Blackjack();
                }
                else
                {
                    GameLose();
                }
            }

            if (YourScore < 21 && !didStand)
            {
                OnNotify();
            }
            if (YourScore < 21 && didStand)
            {
                if (YourScore < DealerScore)
                {
                    GameLose();
                }
                else
                {
                    Stand();
                }
            }
        }

        private void Stand()
        {
            foreach (Card card in DealerHand)
            {
                if (card.Rank == 1 || card.Rank == 10 || card.Rank == 11 || card.Rank == 12 || card.Rank == 13)
                {
                    DealerScore += 10;
                }
                else
                {
                    DealerScore += card.Rank;
                }
            }
            if (this.dealerscore < 21)
             {
                dealerhand.Add(ShuffledDeck[currentCount]);
                currentCount++;
                Stand();
             }
            else
            {
                HandCheck(currentCount);
            }
           
        }

        private void Blackjack()
        {
            MessageBox.Show("Blackjack");
        }

        private void Tie()
        {
            MessageBox.Show("Tie somehow");
        }

        private void GameWin()
        {
            MessageBox.Show("You Win");
        }

        private void GameLose()
        {
            MessageBox.Show("You Lose");
        }

        public ICommand AddCardCommand { get; set; }
        public ICommand StandCommand { get; set; }

        public ObservableCollection<Card> YourHand
        {
            get
            {
                return this.yourhand;
            }
            set
            {
                this.yourhand = value;
                OnNotify();
            }
        }

        public ObservableCollection<Card> DealerHand
        {
            get
            {
                return this.dealerhand;
            }
            set
            {
                this.dealerhand = value;
                OnNotify();
            }
        }

        public int YourScore
        {
            get
            {
                return this.yourscore;
            }
            set
            {
                this.yourscore = value;
                OnNotify();
            }
        }
        public int DealerScore
        {
            get
            {
                return this.dealerscore;
            }
            set
            {
                this.dealerscore = value;
                OnNotify();
            }
        }

    }
}
