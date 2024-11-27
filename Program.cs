using Hangman;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello in Hangman game!");
        Console.WriteLine("Press Enter to start.");
        Console.ReadLine();

        HangmanValue.Game();
    }
}