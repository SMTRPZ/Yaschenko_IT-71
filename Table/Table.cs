using System;
using System.Collections.Generic;
using System.Text;

namespace _15
{
    public abstract class Table
    {
        public Table()
        {

        }

        protected int turns;

        public int Turns { 
            get { return turns; } 
            set { turns = value; } }

        protected int size;
        public int Size{
            get { return size; }
            set { size = value; } }

        protected int[,] positions;
        public int[,] Positions {
            get { return positions; }
            set { positions = value; } }

        public virtual void Turn(string direction) 
        {
            Move(direction);
            this.turns++;
        }

        public bool Move(string direction)
        {
            int ind = FindSpace();
            int x = ind / size;
            int y = ind - (ind / size) * size;
            try
            {
                switch (direction)
                {
                    case "down":
                        MoveDown(x, y);
                        break;
                    case "up":
                        MoveUp(x, y);
                        break;
                    case "left":
                        MoveLeft(x, y);
                        break;
                    case "right":
                        MoveRight(x, y);
                        break;
                }
                return true;
            }
            catch (IndexOutOfRangeException ex)
            {
                //Console.WriteLine(ex.Message);
                return false;
            }
            
        }
        protected void MoveDown(int x, int y)
        {

            int moved = Positions[x + 1, y];
            Positions[x + 1, y] = 0;
            Positions[x, y] = moved;
        }
        protected void MoveUp(int x, int y)
        {
            int moved = Positions[x - 1, y];
            Positions[x - 1, y] = 0;
            Positions[x, y] = moved;
        }
        protected void MoveLeft(int x, int y)
        {
            int moved = Positions[x, y - 1];
            Positions[x, y - 1] = 0;
            Positions[x, y] = moved;
        }
        protected void MoveRight(int x, int y)
        {
            int moved = Positions[x, y + 1];
            Positions[x, y + 1] = 0;
            Positions[x, y] = moved;
        }

        public int FindSpace()
        {
            int ind = 0;
            foreach(int i in Positions)
            {
                if (i == 0) break;
                ind++;
            }
            return ind;
        }
    }
}
   

