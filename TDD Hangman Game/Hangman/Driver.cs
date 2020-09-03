using System;

namespace HangmanGame
{
    class Driver
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Hangman!!!!!!!!!!");
            pAgain:
                Hangman game = new Hangman();
                game.SetupGame("",Enums.Difficulty.Medium);
                // TODO game.Loop();
                game.PlayGame();
                Console.WriteLine("The End!!!!!!!!!!");
                Console.WriteLine("------------------------------------");
                Console.WriteLine("do you want to play again? (y/n)");
                string y = Console.ReadLine();
            if (y == "y")
                goto pAgain;


        }
    }
}
