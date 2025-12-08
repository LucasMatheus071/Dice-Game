using System;

class Program
{
    static Random random = new Random();

    static void Main()
    {
        Console.WriteLine("Play the Dice Game? (Y/N)");

        if (UserWantsToPlay())
            PlayGame();

        Console.WriteLine("Goodbye!");
    }

    static bool UserWantsToPlay()
    {
        string? input = Console.ReadLine();
        return input != null && input.Trim().ToLower() == "y";
    }

    static void CalculandoAnimacao()
    {
        string passo = "-->";

        for (int i = 0; i < 20; i++)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("\r" + new string(' ', i) + passo);
            Thread.Sleep(70);
            //Console.Write($"\r{new string(' ', Console.BufferWidth)}");
            Console.Write("\r");
        }
        Console.Write($"\r{new string(' ', Console.BufferWidth)}");
        Console.ResetColor();
    }
    static void PlayGame()
    {
        int wins = 0;
        int losses = 0;
        bool play = true;

        while (play)
        {
            int target = random.Next(1, 5);
            int roll = random.Next(1, 6);

            Console.WriteLine($"\nTarget: Roll GREATER than {target}!");

            double chance = ((5 - target) / 5.0) * 100;
            Console.WriteLine($"Chance of winning: {chance:F1}%");

            CalculandoAnimacao();

            Console.WriteLine($"\nYou rolled: {roll}");

            if (roll > target)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("You WIN!");
                wins++;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You LOSE!");
                losses++;
            }

            Console.ResetColor();

            Console.WriteLine($"\nWins: {wins}  |  Losses: {losses}");
            Console.WriteLine("Play again? (Y/N)");

            play = UserWantsToPlay();
            Console.Clear();
        }
    }
}