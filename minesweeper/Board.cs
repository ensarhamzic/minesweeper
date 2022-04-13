using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace minesweeper
{
    internal class Board
    {
        private Field[,] fields;
        private int rows;
        private int cols;
        private int mines;
        private int flags;

        public Field[,] Fields
        {
            get { return fields; }
            set { fields = value; }
        }

        public int Flags
        {
            get { return flags; }
            set { flags = value; }
        }

        public int Rows
        {
            get { return rows; }
            set { rows = value; }
        }

        public int Cols
        {
            get { return cols; }
            set { cols = value; }
        }

        public int Mines
        {
            get { return mines; }
            set { mines = value; }
        }

        public Board(MainWindow.dif difficulty)
        {
            if (difficulty == MainWindow.dif.easy)
            {
                cols = 10;
                rows = 8;
                mines = 10;
                flags = 10;
            }
            else if (difficulty == MainWindow.dif.medium)
            {
                cols = 18;
                rows = 14;
                mines = 40;
                flags = 40;
            }
            else if (difficulty == MainWindow.dif.hard)
            {
                cols = 24;
                rows = 20;
                mines = 99;
                flags = 99;
            }
            fields = new Field[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    fields[i, j] = new Field();
                }
            }
        }

        public void SetMines(int x, int y)
        {
            Random rnd = new Random();
            int count = 0;
            while (count < mines)
            {
                int r = rnd.Next(0, rows);
                int c = rnd.Next(0, cols);
                if (r != x || c != y)
                {
                    if (fields[r, c].IsMine == false)
                    {
                        fields[r, c].IsMine = true;
                        count++;
                    }
                }
            }
            CalculateAdjacentMines();
        }

        private void CalculateAdjacentMines()
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (!fields[i, j].IsMine)
                    {
                        int adjacentMines = 0;
                        for (int k = i - 1; k <= i + 1; k++)
                        {
                            for (int l = j - 1; l <= j + 1; l++)
                            {
                                if (k >= 0 && k < rows && l >= 0 && l < cols)
                                {
                                    if (fields[k, l].IsMine)
                                    {
                                        adjacentMines++;
                                    }
                                }
                            }
                        }
                        fields[i, j].AdjacentMines = adjacentMines;
                    }
                }
            }

        }


        public bool MakeTurn(int x, int y, bool first)
        {
            // first = true if user clicked on x,y field
            if(first && fields[x,y].IsMine)
            {
                return true;
            }
            else if (!fields[x, y].IsMine)
            {
                fields[x, y].IsRevealed = true;
                if(fields[x, y].AdjacentMines == 0)
                { 
                    for (int i = x - 1; i <= x + 1; i++)
                    {
                        for (int j = y - 1; j <= y + 1; j++)
                        {
                            if (i >= 0 && i < rows && j >= 0 && j < cols
                                && !fields[i, j].IsRevealed
                                && !fields[i, j].IsFlagged)
                            {
                                MakeTurn(i, j, false);
                            }
                        }
                    }
                }
            }

            return false;
        }
        
        public bool IsWin()
        {
            int numRevealed = 0;
            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                    if (fields[i, j].IsRevealed)
                        numRevealed++;
            if (numRevealed == rows * cols - mines)
                return true;
            return false;
        }

    }
}
