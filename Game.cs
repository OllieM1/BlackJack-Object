using System;

namespace BlackJack_Object
{
    internal class Game
    {
        public bool startGame()
        {

            bool gameloop = false;
            bool playerwin = false;

            Deck deck = new Deck();
            Hand payerHand = new Hand();
            Hand dealerHand = new Hand();

            payerHand.AddCard(deck.dealACard());
            dealerHand.AddCard(deck.dealACard());
            payerHand.AddCard(deck.dealACard());
            dealerHand.AddCard(deck.dealACard());

            Console.WriteLine($"The dealer 1st card is {dealerHand.showdealercard()}");

            while (gameloop == false)
            {
                payerHand.showCards();
                Console.WriteLine("Would you like to Stick (s) or Twist (t)");
                string playerResult = Console.ReadLine();
                if (playerResult == "s")
                {
                    gameloop = true;
                    Console.WriteLine("You have ended your turn");
                }
                else if (playerResult == "t")
                {
                    payerHand.AddCard(deck.dealACard());
                    if (payerHand.bust())
                    {
                        gameloop = true;
                        Console.WriteLine("You have gone bust!");
                    }
                }
            }
            Console.WriteLine($"Your current total is {payerHand.GetValue()}");
            Console.WriteLine(" DEBUG This is dealer total");
            Console.WriteLine(dealerHand.GetValue());

            while (dealerHand.GetValue() <= 16)
            {
                dealerHand.AddCard(deck.dealACard());
            }
            if (dealerHand.GetValue() >= 21)
            {
                Console.WriteLine("The dealer has gone bust");
            }

            if (dealerHand.GetValue() < payerHand.GetValue() && payerHand.bust() == false)
            {
                playerwin = true;
            }

            return playerwin;
        }


    }
}
