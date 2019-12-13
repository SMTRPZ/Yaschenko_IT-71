using System;
using System.Collections.Generic;
using System.Text;

namespace _15
{
    public class CreatorRandomTurnTable : CreatorTable
    {
        public CreatorRandomTurnTable()
        {

        }
        public RandomTurnTable RandomTurnTable
        {
            get => default;
            set
            {
            }
        }

        public override Table FactoryMethod(int size)
        {
            Table table = new RandomTurnTable();
            table.Size = size;
            table.Turns = 0;
            int[,] pos = new int[size, size];
            Random rand = new Random();
            int floating = rand.Next(size / 2);
            FillPartOfTable(pos, size, 0, size * size - 1, 1, size * size - 1);
 
            table.Positions = pos;
            return table;
        }
    }
}