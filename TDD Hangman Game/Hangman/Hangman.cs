// Project name: Hangman game
// Author: Huy Quang Tran
// Created date: 28/08/2020


using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace HangmanGame
{
    public class Hangman
    {
        static string theSecretWord = "";
        public Hangman()
        {
        }

        public bool GuessLetter(string letter)
        {
            bool foundLetter = false;
            if (String.IsNullOrEmpty(letter))
                return false;
            if (letter.Length > 1)
            {
                Console.WriteLine("please enter only 1 letter to play");
                return false;
            }
            for (int i = 0; i < Guesses.Count; i++)
                //checking missing word is correct
                if (Guesses[i] == '_' && SecretWord[i].ToString() == letter.ToUpper())
                {
                    Guesses[i] = char.Parse(letter.ToUpper());
                    Console.WriteLine(letter + " is correct!");
                    return true;// return when letter matched
                }
            //retun when letter not match.
            this.NumberOfGuesses--;
            Console.WriteLine(letter + " is incorrect!");
            return foundLetter; 
        }

        public bool EnterWord(string secretWord)
        {
            if (!string.IsNullOrWhiteSpace(secretWord))
            {
                Random randGen = new Random();
                
                foreach (var item in secretWord.ToUpper().ToCharArray())
                {
                    var idx = randGen.Next(0, 9);
                    if (idx % 2 ==0)
                        this.Guesses.Add('_');
                    else
                        this.Guesses.Add(item);
                    this.SecretWord.Add(item);
                }
                return true;
            }

            return false;
        }

        private List<char> Guesses
        {
            get;
            set;
        } = new List<char>();

        private List<char> SecretWord
        {
            get;
            set;
        } = new List<char>();

        private int NumberOfGuesses
        {
            get;
            set;
        }

        public string Showword(string mysteryWord)
        {
            theSecretWord = mysteryWord;
            return theSecretWord;
        }

        public bool GameOver()
        {
            bool isOver = false;

            if (NumberOfRemainingGuesses() <= 0 || FoundWord())
            {
                isOver = true;
            }

            if (NumberOfRemainingGuesses() <= 0)
            {
                Console.WriteLine("You lose!");
            } else if (FoundWord())
            {
                Console.WriteLine("");
                Console.WriteLine("Congratiation!You won!\n");
                Console.WriteLine("the secret word is " + theSecretWord.ToUpper() + "\n");
            }

            return isOver;
        }

        public void SetDifficulty(Enums.Difficulty difficulty)
        {
            NumberOfGuesses = (int)difficulty;
        }

        public int NumberOfRemainingGuesses()
        {
            return NumberOfGuesses;
        }

        public bool FoundWord()
        {
            bool hasFoundWord = false;

            foreach (char c in SecretWord)
            {
                if (Guesses.Contains(c))
                {
                    hasFoundWord = true;
                }
                else
                {
                    hasFoundWord = false;
                    break;
                }
            }

            return hasFoundWord;
        }

        public bool Loop()
        {
            //Setup Game
            //Play Game
            for (int i = 0; i < this.SecretWord.Count; i++)
                if (this.SecretWord[i]!=this.Guesses[i])
                    return false;
            return true;
        }

        public bool PlayGame()
        {
            // TODO Outputs to concole current guesses, found letters, and remaing free guesses
            // Guess letters (win/lose)
            // Validation checks?
            while (true)
            {
                Console.WriteLine("The word is (times remain: "+this.NumberOfRemainingGuesses().ToString()+"):" +string.Join("",this.Guesses));
                Console.Write("Please enter guess word: ");
                
                GuessLetter(Console.ReadLine());
                if (GameOver())
                {
                    Console.WriteLine("The game has finished!"); 
                    break;
                }
                if (Loop())
                {
                    Console.WriteLine("The GameOver method is failing.");
                    break;
                }
            }
            return false;   
        }

        public bool SetupGame(string mysteryWord,Enums.Difficulty difficulty)
        {
            //enter word
            string[] listwords = new string[10];
            listwords[0] = "sheep";
            listwords[1] = "monitor";
            listwords[2] = "computer";
            listwords[3] = "america";
            listwords[4] = "watermelon";
            listwords[5] = "icecream";
            listwords[6] = "jasmine";
            listwords[7] = "pineapple";
            listwords[8] = "orange";
            listwords[9] = "mango";
            Random randGen = new Random();
            var idx = randGen.Next(0, 9);
            if (mysteryWord=="")
                mysteryWord = listwords[idx];
                theSecretWord = mysteryWord;
            //enter difficulty
            this.EnterWord(mysteryWord);
            this.NumberOfGuesses = (int)difficulty;
            //check values
            return false;
        }
    }
}
