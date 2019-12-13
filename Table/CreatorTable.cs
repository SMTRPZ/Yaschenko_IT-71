using System;
using System.Collections.Generic;
using System.Text;

namespace _15
{
    public abstract class CreatorTable
    {
        public CreatorTable()
        {
            
        }

        public abstract Table FactoryMethod(int size);
        
        protected static int PosToX(int position, int size)
        {
            return position / size;
        } 

        protected static int PosToY(int position, int size)
        {
            return position - (position / size) * size;
        }

        public int FindNumber(int[,] arr, int number)
        {
            int ind = 0;
            foreach (int i in arr)
            {
                if (i == number) break;
                ind++;
            }
            return ind;
        }

        protected void FillPartOfTable(int[,] arr, int size, int beginNumber, int finishNumber, int minNumber, int maxNumber)
        {
            Random rand = new Random();
            bool done = false;
            for (int i = beginNumber; i < finishNumber; i++)
            {
                done = false;
                while (!done)
                {
                    int newnum = rand.Next(minNumber, maxNumber + 1);
                    if (FindNumber(arr, newnum) == arr.Length) //элемента нет в массиве
                    {
                        arr[PosToX(i, size), PosToY(i, size)] = newnum;
                        done = true;
                    }
                }
            }
        }
    }
}