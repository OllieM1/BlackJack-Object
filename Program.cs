using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack_Object
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            bool gamerounds = true;
            int bet = 0;
            int balace = 1000;            
            Console.WriteLine("Welcome to Ollie's Black Jack!");
            Console.WriteLine($"Your Balance is £{balace}");

            while ( gamerounds )
            {
                Console.WriteLine($"How much would you like to bid out of your £{balace}");
                try
                {
                    bet = int.Parse( Console.ReadLine());
                    if (bet > balace) 
                    {
                        Console.WriteLine($"You are betting over your full balance I have set it to £{balace}");
                        bet = balace;
                    }
                    else
                    {
                        balace = balace - bet;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Well done that not a number im setting your bet to your whole balance");
                    bet = balace;
                    balace -= bet;
                }

                Console.WriteLine($"Your bet is {bet}");

                if (game.startGame())
                {
                    Console.WriteLine("Weldone you have won");
                    balace = balace + (2 * bet);
                }
                else
                {
                    Console.WriteLine("HA you lost");
                }
                Console.WriteLine($"Your new balance is £{balace}");
                Console.WriteLine("Play again, you could win your money back (y/n)");                
                if (Console.ReadLine() == "n" )
                {
                    gamerounds = false; 
                }
            }           

            Console.WriteLine("Come Again soon");
            Console.WriteLine($"Your end balance was £{balace}");
            Console.ReadLine();
        }        
    }
}
