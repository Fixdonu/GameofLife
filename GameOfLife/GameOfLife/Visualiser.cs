using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    class Visualiser
    {
        Board curBoard;
        int sleepTime;

        public Visualiser(Board curBoard, int sleepTime )
        {
            this.curBoard = curBoard;
            this.sleepTime = sleepTime;
            Start();
        }

        void ShowBoard()
        {
            int[,] curMap = curBoard.Map;

            for (int i = 0; i < curBoard.Size; i++)
            {
                for (int j = 0; j < curBoard.Size; j++)
                {
                    if (curMap[i, j] == 0)
                    {
                        Console.Write(" ");
                    }
                    else Console.Write(curMap[i,j]);
                }

                Console.WriteLine("");
            }
        }

        void Start()
        {
            while(true)
            {
                ShowBoard();
                System.Threading.Thread.Sleep(sleepTime);
                Console.Clear();
                curBoard.NextTurn();
            }
        }
    }
}
