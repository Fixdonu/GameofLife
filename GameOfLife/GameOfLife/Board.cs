using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    public class Board
    {
        Random rng = new Random();
        int size = 0;
        public int Size
        {
            get { return size; }
        }

        int[,] tmpMap;
        int[,] map;
        public int[,] Map
        {
            get { return map; }
        }
        
        public Board(int size){
            this.size = size;
            map = new int[size,size];
            tmpMap = new int[size, size];
          
            SeedLife();
        }

        //Selects spot and fill with a 3x3 pattern
        void SeedLife()
        {
            //Rng position for seed
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    map[i, j] = rng.Next(2);
                }
            }
        }

        public void NextTurn()
        {
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    Rules(i, j);
                }
            }
            map = tmpMap;
        }

        void Rules(int row, int col)
        {
            int tileVal = 0;
            int noLive = 0;

            if ((row == 0 && col == 0) || (row == 0 && col == Size - 1)
                || (row == Size - 1 && col == 0) || (row == Size - 1 && col == Size - 1))
            {
                noLive = CornerCase(row, col);
            }
            else if (row == 0 || row == Size - 1 || col == 0 || col == Size - 1)
            {
                noLive = SideCase(row, col);
            }
            else noLive = NormalCase(row, col);

            switch (noLive)
            {
                case 2:
                    if (Map[row,col] == 1)
                    {
                        tileVal = 1;
                    }
                    break;
                case 3:
                    tileVal = 1;
                    break;
                default:
                    break;

            }
            tmpMap[row,col] = tileVal;
        }

        /*
        void DeadRules(int row, int col)
        {
            int tileVal = 0;
            if ((row == 0 && col == 0) || (row == 0 && col == Size - 1)
                || (row == Size - 1 && col == 0) || (row == Size - 1 && col == Size - 1))
            {
                if (CornerCase(row, col) == 3)
                {
                    tileVal = 1;
                }
            }
            else if (row == 0 || row == Size-1 || col == 0 || col == Size-1)
            {
                if (SideCase(row, col) == 3)
                {
                    tileVal = 1;
                }
            }
            else if (NormalCase(row, col) == 3)
            {
                tileVal = 1;
            }
            tmpMap[row, col] = tileVal;
        }*/

        int CornerCase(int row, int col)
        {
            int noLive = 0;
            if (row == 0 && col == 0)
            {
                noLive += Map[1, 0] + Map[1, 1] + Map[0, 1];
            }
            else if (row == 0 && col == Size-1)
            {
                noLive += Map[1, Size-1] + Map[1, Size-2] + Map[0, Size-2];
            }
            else if (row == Size-1 && col == 0)
            {
                noLive += Map[Size-2, 0] + Map[Size-2, 1] + Map[Size-1, 1];
            }
            else noLive += Map[Size-2, Size-1] + Map[Size-2, Size-2] + Map[Size-1,Size-2];
            return noLive;
        }

        int SideCase(int row, int col)
        {
            int noLive = 0;
            if (row == 0)
            {
                noLive += Map[row, col - 1] + Map[row, col + 1] + Map[row + 1, col - 1]
                    + Map[row + 1, col] + Map[row + 1, col + 1];
            }
            else if (row == Size - 1)
            {
                noLive += Map[row, col - 1] + Map[row, col + 1] + Map[row - 1, col - 1]
                    + Map[row - 1, col] + Map[row - 1, col + 1];
            }
            else if (col == 0)
            {
                noLive += Map[row - 1, col] + Map[row + 1, col] + Map[row + 1, col + 1]
                    + Map[row, col + 1] + Map[row - 1, col + 1];
            }
            else
            {
                noLive += Map[row - 1, col] + Map[row + 1, col] + Map[row + 1, col - 1]
                    + Map[row, col - 1] + Map[row - 1, col - 1];
            }

            return noLive;
        }

        int NormalCase(int row, int col)
        {
            int noLive = 0;

            noLive += Map[row - 1, col - 1] + Map[row - 1, col] + Map[row - 1, col + 1]
                    + Map[row, col - 1] + Map[row, col + 1]
                    + Map[row + 1, col - 1] + Map[row + 1, col] + Map[row + 1, col + 1];

            return noLive;
        }
    }
}
