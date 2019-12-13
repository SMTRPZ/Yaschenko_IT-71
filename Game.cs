using System;
using System.Collections.Generic;
using System.Text;

namespace _15
{
    public class Game
    {
        private static Game instance;
        private string name;
        private string complexity;

        public string Complexity { get { return complexity; } set { name = value; } }
        public string Name { get { return name; } set { name = value; } }
        public Table table;
        
        public Game(string name, string complexity, int dimension)
        {
            CreatorTable cr = new CreatorEasyTable();
            switch (complexity)
            {
                case "Easy":
                    cr = new CreatorEasyTable();
                    break;
                case "Hard":
                    cr = new CreatorHardTable();
                    break;
                case "RandomTurn":
                    cr = new CreatorRandomTurnTable();
                    break;
            }
            //Invoker invoker = new Invoker();
            //CreatorRandomTurnTable cr = new CreatorRandomTurnTable();
            Table table = cr.FactoryMethod(dimension);
            this.table = table;
            this.name = name;
            this.complexity = complexity;
        }

        public static Game getInstance()
        {
            return instance;
        }
        public static Game newInstance(string name, string complexity, int dimension)
        {
            instance = new Game(name, complexity, dimension);
            return instance;
        }

        public void printTable()
        {
            for (int i = 0; i < table.Size; i++)
            {
                for (int j = 0; j < table.Size; j++)
                {
                    Console.Write(String.Format("{0,3}", table.Positions[i, j]));
                }
                Console.WriteLine();
            }
        }


        public void SaveGame()
        {

        }


        public void LoadGame()
        {

        }

        public Memento CreateMemento()
        {
            return new Memento(this.Name, this.table.Size, this.Complexity, this.table.Positions);
        }

        public void RestoreMemento(Memento mem)
        {
            this.name = mem.Name;
            this.table.Size = mem.Dimension;
            this.table.Positions = mem.Positions;
        }

        public Command Command
        {
            get => default;
            set
            {
            }
        }
    }
}