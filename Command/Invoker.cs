using System;
using System.Collections.Generic;
using System.Text;

namespace _15
{
    public class Invoker
    {
        Command command;

        public Command Command
        {
            get => default;
            set
            {
            }
        }

        public void Run(string direction)
        {
            command.Execute(direction);
        }

        public void Cancel()
        {
            command.Undo();
        }

        public void SetCommand(Command c)
        {
            command = c;
        }
    }
}