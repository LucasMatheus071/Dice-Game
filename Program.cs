using System;
using System.IO;
using System.Collections.Generic;
using System.Text.Json;
using System.IO.Pipelines;
using System.Runtime.CompilerServices;

public class UserDice
{
    public string DiceNick { get; set; } = "";
    public int Points { get; set; } = 0;

    public UserDice() { }

    public UserDice(string nickname)
    {
        DiceNick = nickname;
        Console.WriteLine($"Hello {DiceNick}, welcome to DiceGame!");
    }

    public void SumPoints() => Points++;
    public void MinusPoints() => Points--;
    public int ShowPoints() => Points;
}

class Program
{
    const string caminhoArquivo = "Users.json";
    static List<UserDice> users = Carregar();
    static UserDice? jogadorAtual = null;
    static Random random = new Random();

    static void Main()
    {
        string? entrada;

        while (true)
        {
            Console.WriteLine("\n1 - Load Game");
            Console.WriteLine("2 - New Game");
            Console.WriteLine("exit - sair");
            entrada = Console.ReadLine();

            switch (entrada)
            {
                case "exit":
                    if (jogadorAtual != null)
                        Console.WriteLine($"Thanks for playing, goodbye {jogadorAtual.DiceNick}!");
                    else
                        Console.WriteLine("Thanks for playing!");
                    return;
                case "1":
                    if (LoadGame())
                    {
                        PreLoad();
                        PlayGame();
                    }
                    Salvar(users);
                    break;
                case "2":
                    if (NewGame())
                    {
                        PreLoad();
                        PlayGame();
                    }
                    Salvar(users);
                    break;
                default:
                    break;
            }
        }
    }
    static bool LoadGame()
    {
        Console.WriteLine("Enter the player's name:");
        string nickname = Console.ReadLine() ?? "";

        jogadorAtual = users.FirstOrDefault(p => p.DiceNick == nickname);

        if (jogadorAtual == null)
        {
            Console.WriteLine("Player not found.");
            return false;
        }
        else
        {
            Console.WriteLine($"{jogadorAtual.DiceNick} selected! Points: {jogadorAtual.Points}");
            return true;
        }
    }
    static bool NewGame()
    {
        Console.WriteLine("Enter nickname:");
        string nickname = Console.ReadLine() ?? "";

        if (!VerificarAutenticidade(nickname))
        {
            Console.WriteLine("Invalid name: minimum 4 characters, no spaces.");
            return false;
        }

        if (!VerificarDuplo(nickname, users))
        {
            Console.WriteLine("Name already exists!");
            return false;
        }

        jogadorAtual = new UserDice(nickname);
        users.Add(jogadorAtual);

        Salvar(users);
        return true;
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
                jogadorAtual.SumPoints();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You LOSE!");
                losses++;
                jogadorAtual.MinusPoints();

            }

            Console.ResetColor();

            Console.WriteLine($"\nWins: {wins}  |  Losses: {losses}");
            Console.WriteLine("Play again? (Y/N)");

            play = UserWantsToPlay();
            if (play)
                Console.Clear();
        }
    }

    static bool UserWantsToPlay()
    {
        string? input = Console.ReadLine();
        return input != null && input.Trim().ToLower() == "y";
    }
    static void CalculandoAnimacao()
    {
        string frame = "-->";

        for (int i = 0; i < 20; i++)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("\r" + new string(' ', i) + frame);
            Thread.Sleep(70);
        }
        Console.Write($"\r{new string(' ', Console.BufferWidth - 1)}");
        Console.ResetColor();
    }
    static void PreLoad()
    {
        string[] passos = { "|*    ", "| *   ", "  *   ", "   * |", "    *|" };
        int count = 0;

        while (count < 40)
        {

            for (int i = 0; i < passos.Length; i++)
            {
                Console.ForegroundColor = ConsoleColor.Blue;

                Console.Write("\r" + passos[i].PadRight(Console.WindowWidth));
                Thread.Sleep(100);

                count++;
            }

            for (int i = passos.Length - 1; i >= 0; i--)
            {
                Console.ForegroundColor = ConsoleColor.Blue;

                Console.Write("\r" + passos[i].PadRight(Console.WindowWidth));
                Thread.Sleep(100);

                count++;
            }
        }

        Console.Write("\r" + new string(' ', Console.WindowWidth - 1));
        Console.ResetColor();
        
    }

    static List<UserDice> Carregar()
    {
        if (!File.Exists(caminhoArquivo))
            return new List<UserDice>();

        string json = File.ReadAllText(caminhoArquivo);
        return JsonSerializer.Deserialize<List<UserDice>>(json)
        ?? new List<UserDice>();
    }

    static void Salvar(List<UserDice> users)
    {
        string json = JsonSerializer.Serialize(users, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(caminhoArquivo, json);
    }

    public static bool VerificarDuplo(string user, List<UserDice> users)
    {
        return users.All(p => p.DiceNick != user);
    }

    public static bool VerificarAutenticidade(string user)
    {
        return user.Trim().Length >= 4 && !user.Contains(' ');
    }
}