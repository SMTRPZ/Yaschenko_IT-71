using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace _15
{
    class Program
    {
        static void Main(string[] args)
        {
            Caretaker caretaker = new Caretaker();
            Menu(null, null, caretaker, false);
            
        }

        static void Menu(Game game, Invoker invoker, Caretaker caretaker, bool loadenGame)
        {
            List<string> variants = new List<string> { "New game", "Load game", "Quit" };
            if (loadenGame)
            {
                variants.Insert(0, "Save game");
                variants.Insert(0, "Continue");
            }
            int CountLine = 0;
            ConsoleKeyInfo key;
            do
            {
                Console.Clear();
                for ( int i = 0; i < variants.ToArray().Length; i++)
                {
                    if (i == CountLine) Console.BackgroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(variants.ToArray()[i]);
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                key = Console.ReadKey();
                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        if(CountLine > 0) CountLine--;
                        break;
                    case ConsoleKey.DownArrow:
                        if(CountLine < variants.ToArray().Length) CountLine++;
                        break;
                    case ConsoleKey.Enter:
                        GameOperation(variants.ToArray()[CountLine], game, invoker, caretaker);
                        break;
                }

            }
            while (key.Key != ConsoleKey.Escape);
        }

        static void GameOperation(string command, Game game, Invoker invoker, Caretaker caretaker)
        {
            switch (command)
            {
                case "Continue":
                    Playing(game, invoker, caretaker);
                    break;
                case "Save game":
                    SaveGame(game, caretaker);
                    break;
                case "New game":
                    StartGame(caretaker);
                    break;
                case "Load game":
                    ChooseLoadGame(caretaker);
                    break;
                case "Quit":
                    Environment.Exit(0);
                    break;
            }
        }

        static void StartGame(Caretaker caretaker) //ValueTuple<Game, Invoker, Command>
        {
            string name = GetName();
            string complexity = GetComplexity();
            int dimension = GetDimension();

            Invoker invoker = new Invoker();
            Game game = Game.newInstance(name, complexity, dimension);
            Command command = new Command(game.table);
            invoker.SetCommand(command);

            //return (game, invoker, command);
            Playing(game, invoker, caretaker);
        }

        static void SaveGame(Game game, Caretaker caretaker)
        {
            caretaker.SaveGame(game.CreateMemento());
        }

        static void ChooseLoadGame(Caretaker caretaker)
        {
            int CountLine = 0;
            ConsoleKeyInfo key;
            Memento[] arr = caretaker.games.ToArray();
            do
            {
                Console.Clear();
                for (int i = 0; i < arr.Length; i++)
                {
                    if (i == CountLine) Console.BackgroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(arr[i].Name, "   ", arr[i].Dimension);
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                key = Console.ReadKey();
                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (CountLine > 0) CountLine--;
                        break;
                    case ConsoleKey.DownArrow:
                        if (CountLine < arr.Length) CountLine++;
                        break;
                    case ConsoleKey.Enter:
                        LoadGame(caretaker, arr[CountLine].Name, arr[CountLine].Dimension);
                        break;
                }

            }
            while (key.Key != ConsoleKey.Escape);
        }
        static void LoadGame(Caretaker caretaker, string name, int dimension)
        {

            Memento mem = caretaker.GetMemento(name, dimension);
            Invoker invoker = new Invoker();
            Game game = Game.newInstance(mem.Name, mem.Complexity, mem.Dimension);
            game.RestoreMemento(mem); // может повторение верхней строки
            Command command = new Command(game.table);
            invoker.SetCommand(command);

            //return (game, invoker, command);
            Playing(game, invoker, caretaker);
        }

        static void Playing(Game game, Invoker invoker, Caretaker caretaker)
        {
            ConsoleKeyInfo key;
            do
            {
                Console.Clear();
                game.printTable();
                key = Console.ReadKey();
                switch (key.Key)
                {
                    case ConsoleKey.DownArrow:
                        invoker.Run("down");
                        break;
                    case ConsoleKey.UpArrow:
                        invoker.Run("up");
                        break;
                    case ConsoleKey.LeftArrow:
                        invoker.Run("left");
                        break;
                    case ConsoleKey.RightArrow:
                        invoker.Run("right");
                        break;
                    case ConsoleKey.Z:
                        invoker.Cancel();
                        break;
                }
            }
            while (key.Key != ConsoleKey.Escape);
            Menu(game, invoker, caretaker, true);
        }

        static string GetName()
        {
            Console.Clear();
            Console.WriteLine("Type your name please");
            return Console.ReadLine();
        }

        static string GetComplexity()
        {
            Console.Clear();
            Console.WriteLine("Type your complexity please(Easy, Hard, RandomTurn)");
            string[] available = { "Easy", "Hard", "RandomTurn" };
            string input = Console.ReadLine();
            if (!Array.Exists(available, element => element == input)) return GetComplexity();
            return input;
        }

        static int GetDimension()
        {
            Console.Clear();
            Console.WriteLine("Type your dimension please");
            string input = Console.ReadLine();
            try
            {
                return Int32.Parse(input);
            }
            catch (FormatException)
            {
                return GetDimension();
            }
        }
    }
}
