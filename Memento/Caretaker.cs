using System;
using System.Collections.Generic;
using System.Text;

namespace _15
{
    public class Caretaker
    {
        public List<Memento> games { get; private set; }

        public Memento Memento
        {
            get => default;
            set
            {
            }
        }

        public Game Game
        {
            get => default;
            set
            {
            }
        }

        public Caretaker()
        {
            games = new List<Memento>();
        }

        public void SaveGame(Memento mem)
        {
            games.Add(mem);
        }

        public Memento GetMemento(string name, int dimension)
        {
            foreach (Memento value in games)
            {
                if (value.Name == name && value.Dimension == dimension)
                {
                    return value;
                }
            }
            return null;
        }
    }
}