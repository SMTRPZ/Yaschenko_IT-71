using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _15
{
    
    public class Command
    {
        Table table;
        public Command(Table t)
        {
            table = t;
            moves = new List<string>(10);
        }

        private List<string> moves;
        public void Execute(string direction)
        {
            if(table.Move(direction)) 
                moves.Add(direction);
            if (moves.Count == 11)
                moves.Remove(moves.First());
        }

        public void Undo()
        {
            if (moves.Count != 0)
            {
                table.Move(UndoDirection(moves.Last()));
                moves.Remove(moves.Last());
            }
        }

        public string UndoDirection(string direction)
        {
            switch (direction)
            {
                case "up":
                    return "down";
                case "down":
                    return "up";
                case "left":
                    return "right";
                case "right":
                    return "left";
                default:
                    return "";
            }
        }

        public Table Table
        {
            get => default;
            set
            {
            }
        }
    }
}