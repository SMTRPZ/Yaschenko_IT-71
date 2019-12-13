using System;
using System.Collections.Generic;
using System.Text;

namespace _15
{
    public class Memento
    {
        public Memento(string name, int dimension, string complexity, int[,] positions)
        {
            this.Name = name;
            this.Dimension = dimension;
            this.Positions = positions;
            this.Complexity = complexity;
        }
        public string Name { get; private set; }
        public int Dimension { get; private set; }
        public string Complexity { get; private set; }
        public int[,] Positions { get; private set; }
    }
}