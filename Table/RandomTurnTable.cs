using System;
using System.Collections.Generic;
using System.Text;

namespace _15
{
    public class RandomTurnTable : Table
    {
       public override void Turn(string direction)
        {
            string[] randomDirections = { "up", "down", "left", "right" };
            Move(direction);
            this.turns++;
            Random rand = new Random();
            for(int i = 0; i < rand.Next(3); i++)
            {
                Move(randomDirections[rand.Next(3)]);
                this.turns++;
            }
        }
    }
}