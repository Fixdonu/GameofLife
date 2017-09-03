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
            int size;
            int refreshRate;
            Console.WriteLine("How big is the board?:");

            while (!int.TryParse(Console.ReadLine(), out size))
            {
                Console.Clear();
                Console.WriteLine("Please provide an integer.");
                Console.WriteLine("How big is the board?:");
            }
            Console.Clear();
            Console.WriteLine("How fast should the game progress in milleseconds?:");

            while (!int.TryParse(Console.ReadLine(), out refreshRate))
            {
                Console.Clear();
                Console.WriteLine("Please provide an integer.");
                Console.WriteLine("How fast should the game progress in milleseconds?:");
            }

            Board board1 = new Board(size);
            Visualiser vis = new Visualiser(board1,refreshRate);
        }
    }
}
