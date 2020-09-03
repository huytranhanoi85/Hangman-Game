using System;
namespace HangmanGame
{
    /// <summary>
    /// Initial ideas for creating an interface for console input and output.
    /// Then we can output to a console for the game, or mock it out for unit testing.
    /// More info: https://stackoverflow.com/a/3161361
    /// </summary>
    public interface IConsole
    {
        void Question();
        void Answer();
        void Execute();
    }
}
