namespace blackjack
{
    using System;
    using System.Collections.Generic;

    public class Game
    {
        public List<Card> Deck = new List<Card>();
        public List<Card> YourHand = new List<Card>();
        public List<Card> DealerHand = new List<Card>();

        public int YourValue = 0;
        public int DealerValue = 0;

        public bool DidStand = false;
        public bool gameover = false;





     public void StartGame(List<Card> deck)
     {
         gameover = false;
         int number = 4;
        this.Deck = deck;
        MainGame(number);
     }

     public void MainGame(int count)
     {
         for (var i = 1; i < count; i++){
             if (i % 2 == 1){
                YourHand.Add(Deck[i]);
             } else {
                 DealerHand.Add(Deck[i]);
             }
         }
        HandCheck(count);

     }

        private void HandCheck(int count)
        {
            int cardvalue = 0;
            int dealercardvalue = 0;
            System.Console.WriteLine($"\n\nYour Cards:");
         foreach(Card card in YourHand)
         {
            cardvalue += card.Rank;
            card.PrintCardToScreen();
            YourValue = cardvalue;
         }
         System.Console.WriteLine($"Points: {YourValue}");
         System.Console.WriteLine("\n");
         System.Console.WriteLine($"Dealer's Card:");
         foreach(Card card in DealerHand)
         {
             dealercardvalue += card.Rank;
            card.PrintCardToScreen();
            DealerValue = dealercardvalue;
            if (DealerValue > 21 && card.Rank == 11){

            }
         }
         System.Console.WriteLine($"Points: {DealerValue}");

         if (YourValue > 21 || DealerValue > 21)
         {
             foreach(Card card in YourHand){
                 if (YourValue > 21 && card.Rank == 11){
                YourValue = cardvalue - 10;
                HandCheck(count);
                }
                }
             foreach(Card card in DealerHand){
                 if (DealerValue > 21 && card.Rank == 11){
                DealerValue = cardvalue - 10;
                HandCheck(count);
                }
             }
             if (YourValue > 21 && DealerValue > 21)
             {
                 GameLose();
             }
             else if (YourValue > 21)
             {
                 GameLose();
             }
             else if (DealerValue > 21)
             {
                 GameWin();
             }
         }
         if (YourValue == 21 || DealerValue == 21){
             if (YourValue == 21 && DealerValue == 21){
                 Tie();
             } else if (YourValue == 21){
                 Blackjack();
             } else {
                 GameLose();
             }
         }

         if (YourValue < 21 && !DidStand){
         System.Console.WriteLine("\nWould you like to hit (H) or stand (S)?");
         var input = Console.ReadLine();
         if (input == "h")
         {
             AddCard(count);
         } else {
             Stand(count);
         }
         }
         if (YourValue < 21 && DidStand){
             if (YourValue < DealerValue){
                 GameLose();
             } else {
                 Stand(count);
             }
         }
        }


        public void AddCard(int count)
     {
            YourHand.Add(Deck[count]);
            count += 1;
            HandCheck(count);
     }

     public void Stand(int count)
     {
         if (DealerValue + Deck[count].Rank < 21)
         {
             DealerHand.Add(Deck[count]);
             count += 1;
             HandCheck(count);
         }
     }
    public void GameWin()
    {
        string str = @"
                                                                                   
                                                                                   
                                                        .---.                      
        ,---,                                          /. ./|  ,--,                
       /_ ./|   ,---.           ,--,               .--'.  ' ;,--.'|         ,---,  
 ,---, |  ' :  '   ,'\        ,'_ /|              /__./ \ : ||  |,      ,-+-. /  | 
/___/ \.  : | /   /   |  .--. |  | :          .--'.  '   \' .`--'_     ,--.'|'   | 
 .  \  \ ,' '.   ; ,. :,'_ /| :  . |         /___/ \ |    ' ',' ,'|   |   |  ,' | 
  \  ;  `  ,''   | |: :|  ' | |  . .         ;   \  \;      :'  | |   |   | /  | | 
   \  \    ' '   | .; :|  | ' |  | |          \   ;  `      ||  | :   |   | |  | | 
    '  \   | |   :    |:  | : ;  ; |           .   \    .\  ;'  : |__ |   | |  |/  
     \  ;  ;  \   \  / '  :  `--'   \           \   \   ' \ ||  | '.'||   | |--'   
      :  \  \  `----'  :  ,      .-./            :   '  |-- ;  :    ;|   |/       
       \  ' ;           `--`----'                 \   \ ;    |  ,   / '---'        
        `--`                                       '---'                    
                                                                                   
";
        System.Console.WriteLine("\n\n-------------------------------------------");
        System.Console.WriteLine("\n"+ str);
        while (!gameover){
        System.Console.WriteLine("Would you like to play again? Y/N ");
        var input = Console.ReadLine();
        if (input == "y" || input == "Y")
        {
            gameover = true;
            Program game = new Program();
            game.StartGame();
        } else {
         break;   
        }
        }
    }
    public void Blackjack()
    {
        string str = @"
 /$$$$$$$  /$$                     /$$          /$$$$$  /$$$$$$            /$$      
| $$__  $$| $$                    | $$         |__  $$ /$$__  $$          | $$      
| $$  \ $$| $$  /$$$$$$   /$$$$$$$| $$   /$$      | $$| $$  \ $$  /$$$$$$$| $$   /$$
| $$$$$$$ | $$ |____  $$ /$$_____/| $$  /$$/      | $$| $$$$$$$$ /$$_____/| $$  /$$/
| $$__  $$| $$  /$$$$$$$| $$      | $$$$$$/  /$$  | $$| $$__  $$| $$      | $$$$$$/ 
| $$  \ $$| $$ /$$__  $$| $$      | $$_  $$ | $$  | $$| $$  | $$| $$      | $$_  $$ 
| $$$$$$$/| $$|  $$$$$$$|  $$$$$$$| $$ \  $$|  $$$$$$/| $$  | $$|  $$$$$$$| $$ \  $$
|_______/ |__/ \_______/ \_______/|__/  \__/ \______/ |__/  |__/ \_______/|__/  \__/
                                                                                                                                                                       
";
        System.Console.WriteLine("\n\n-------------------------------------------");
        System.Console.WriteLine("\n"+str);
        while (!gameover){
        System.Console.WriteLine("Would you like to play again? Y/N ");
        var input = Console.ReadLine();
        if (input == "y" || input == "Y")
        {
            gameover = true;
            Program game = new Program();
            game.StartGame();
        } else {
         break;   
        }
        }
    }
    public void Tie()
    {
        System.Console.WriteLine("\n\n-------------------------------------------");
        System.Console.WriteLine(@"\n.------..------..------..------.     .------..------..------..------.
|G.--. ||A.--. ||M.--. ||E.--. |.-.  |T.--. ||I.--. ||E.--. ||D.--. |
| :/\: || (\/) || (\/) || (\/) ((5)) | :/\: || (\/) || (\/) || :/\: |
| :\/: || :\/: || :\/: || :\/: |'-.-.| (__) || :\/: || :\/: || (__) |
| '--'G|| '--'A|| '--'M|| '--'E| ((1)) '--'T|| '--'I|| '--'E|| '--'D|
`------'`------'`------'`------'  '-'`------'`------'`------'`------'");
        while (!gameover){
        System.Console.WriteLine("Would you like to play again? Y/N ");
        var input = Console.ReadLine();
        if (input == "y" || input == "Y")
        {
            gameover = true;
            Program game = new Program();
            game.StartGame();
        } else {
         break;   
        }
        }
    }

    public void GameLose()
    {
        string str = @"
  _____             _            __          ___           
 |  __ \           | |           \ \        / (_)          
 | |  | | ___  __ _| | ___ _ __   \ \  /\  / / _ _ __  ___ 
 | |  | |/ _ \/ _` | |/ _ \ '__|   \ \/  \/ / | | '_ \/ __|
 | |__| |  __/ (_| | |  __/ |       \  /\  /  | | | | \__ \
 |_____/ \___|\__,_|_|\___|_|        \/  \/   |_|_| |_|___/
                                                           
                                                           
";
        System.Console.WriteLine("\n\n-------------------------------------------");
        System.Console.WriteLine("\n"+str);
         while (!gameover){
        System.Console.WriteLine("Would you like to play again? Y/N ");
        var input = Console.ReadLine();
        if (input == "y" || input == "Y")
        {
            gameover = true;
            Program game = new Program();
            game.StartGame();
        } else {
            break;   
        }
        }
    }

    }
}