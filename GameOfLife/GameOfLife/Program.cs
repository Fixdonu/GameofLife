using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {
            Board board1 = new Board(50);
            Visualiser vis = new Visualiser(board1,5000);
        }
    }
}
