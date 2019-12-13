using System;
using System.Collections.Generic;
using System.Text;

namespace _15
{
    public class CreatorHardTable : CreatorTable
    {
        public CreatorHardTable()
        {

        }
        public HardTable HardTable
        {
            get => default;
            set
            {
            }
        }

        public override Table FactoryMethod(int size)
        {
            Table table = new HardTable();
            table.Size = size;
            table.Turns = 0;
            int[,] pos = new int[size, size];
            Random rand = new Random();
            int floating = rand.Next(size / 2);
            FillPartOfTable(pos, size, 0, size * size / 2 - 1 + floating, (size * size / 2) + 1 - floating, size * size - 1);
            FillPartOfTable(pos, size, (size * size / 2) - 1 + floating, size * size - 1, 0, (size * size / 2) + floating);

            table.Positions = pos;
            return table;
        }
    }
}