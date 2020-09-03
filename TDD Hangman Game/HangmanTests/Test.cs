using NUnit.Framework;
using System;
using HangmanGame;

namespace HangmanTests
{
    [TestFixture()]
    public class Test
    {
        [Test()]
        public void Hangman_GuessLetter_Positive()
        {
            Hangman game = new Hangman();
            game.EnterWord("All");
            bool isFound = game.GuessLetter("a");

            Assert.AreEqual(true, isFound, "The guess is correct.");
        }

        [Test()]
        public void Hangman_GuessLetter_Negative()
        {
            // declare project
            Hangman game = new Hangman();
            // defind a word "All"
            game.EnterWord("All");
            // enter wrong word into function for checking 
            // if return false it mean user get worng
            bool isFound = game.GuessLetter("z");
            // resule expected is false. When player input incorrect.
            Assert.AreEqual(false, isFound, "The guess is wrong.");
        }

        [Test()]
        public void Hangman_EnterWord_Blank()
        {
            Hangman game = new Hangman();

            bool isSuccessful = game.EnterWord("");

            Assert.AreEqual(false, isSuccessful, "The EnterWord method has failed");
        }

        [Test()]
        public void Hangman_GameOver_NumberOfGuesses_True()
        {
            Hangman game = new Hangman();
            game.SetDifficulty(Enums.Difficulty.Medium);
            game.EnterWord("All");

            game.GuessLetter("b");
            game.GuessLetter("i");
            game.GuessLetter("u");
            game.GuessLetter("k");
            game.GuessLetter("c");
            game.GuessLetter("d");

            bool isOver = game.GameOver();

            Assert.AreEqual(true, isOver, "The GameOver method has failed.");
        }

        // TODO Clean up names and add more tests

        [Test()]
        public void Hangman_GameOver_FoundWord_True()
        {
            Hangman game = new Hangman();
            game.SetDifficulty(Enums.Difficulty.Medium);
            game.EnterWord("All");

            game.GuessLetter("a");
            game.GuessLetter("L");

            bool isOver = game.GameOver();

            Assert.AreEqual(true, isOver, "The GameOver method has failed.");
        }

        [Test()]
        public void Hangman_GameOver_NumberOfGuesses_False()
        {
            Hangman game = new Hangman();
            game.SetDifficulty(Enums.Difficulty.Medium);

            bool isOver = game.GameOver();

            Assert.AreEqual(false, isOver, "The GameOver method has failed");
        }

        [Test()]
        public void Hangman_GameOver_FoundWord_False()
        {
            Hangman game = new Hangman();
            game.SetDifficulty(Enums.Difficulty.Medium);
            game.EnterWord("All");
            game.GuessLetter("S");
            game.GuessLetter("e");
            game.GuessLetter("c");

            bool isOver = game.GameOver();

            Assert.AreEqual(false, isOver, "The GameOver method has failed.");
        }

        [Test()]
        public void Hangman_NumberOfRemainingGuesses_Easy()
        {
            Hangman game = new Hangman();
            game.SetDifficulty(Enums.Difficulty.Easy);

            int remainingGuesses = game.NumberOfRemainingGuesses();

            Assert.AreEqual((int)Enums.Difficulty.Easy, remainingGuesses, "The NumberOfRemainingGuess method is not correct.");
            Assert.AreEqual(10, remainingGuesses, "The Difficult level is set wrong.");
        }

        [Test()]
        public void Hangman_NumberOfRemainingGuesses_Medium()
        {
            Hangman game = new Hangman();
            game.SetDifficulty(Enums.Difficulty.Medium);

            int remainingGuesses = game.NumberOfRemainingGuesses();

            Assert.AreEqual((int)Enums.Difficulty.Medium, remainingGuesses, "The NumberOfRemainingGuess method is not correct.");
            Assert.AreEqual(5, remainingGuesses, "The Difficulty is set wrong.");
        }

        [Test()]
        public void Hangman_NumberOfRemainingGuesses_Hard()
        {
            Hangman game = new Hangman();
            game.SetDifficulty(Enums.Difficulty.Hard);

            int remainingGuesses = game.NumberOfRemainingGuesses();

            Assert.AreEqual((int)Enums.Difficulty.Hard, remainingGuesses, "The NumberOfRemainingGuess method is not correct.");
            Assert.AreEqual(2, remainingGuesses, "The Difficult level is wrong.");
        }

        [Test()]
        public void Hangman_FoundWord_Empty()
        {
            Hangman game = new Hangman();

            bool hasFoundWord = game.FoundWord();

            Assert.AreEqual(false, hasFoundWord, "The FoundWord method failed.");
        }

        [Test()]
        public void Hangman_FoundWord()
        {
            Hangman game = new Hangman();

            game.EnterWord("Secret");
            game.GuessLetter("S");
            game.GuessLetter("r");
            game.GuessLetter("c");
            game.GuessLetter("t");
            game.GuessLetter("e");
            bool hasFoundWord = game.FoundWord();

            Assert.AreEqual(true, hasFoundWord, "The FoundWord method failed.");
        }

        [Test()]
        public void Hangman_Loop()
        {
            Hangman game = new Hangman();
            //TODO While game isn't over, loop to take input
            game.EnterWord("Secret");
            game.GuessLetter("S");
            game.GuessLetter("e");
            game.GuessLetter("c");
            game.GuessLetter("r");
            game.GuessLetter("e");
            game.GuessLetter("t");
            bool hasWon = game.Loop();

            Assert.AreEqual(true, hasWon, "The player should have won.");
        }
    }
}
