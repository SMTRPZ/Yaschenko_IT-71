using System;
using System.Collections.Generic;
using System.Text;

namespace _15
{
    public class CreatorEasyTable : CreatorTable
    {
        public CreatorEasyTable()
        {

        }
        public EasyTable EasyTable
        {
            get => default;
            set
            {
            }
        }

        public override Table FactoryMethod(int size)
        {
            Table table = new EasyTable();
            table.Size = size;
            table.Turns = 0;
            int[,] pos = new int[size, size];
            Random rand = new Random();
            int floating = rand.Next(size / 2);
            FillPartOfTable(pos, size, 0, size * size / 2 + floating, 1, size * size / 2);
            FillPartOfTable(pos, size, (size * size / 2) + floating + 1, size * size, (size * size / 2) + 1, size * size - 1);

            table.Positions = pos;
            return table;
        }


    }
}