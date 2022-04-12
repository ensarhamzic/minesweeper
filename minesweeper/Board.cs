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
            }
            else if (difficulty == MainWindow.dif.medium)
            {
                cols = 18;
                rows = 14;
                mines = 40;
            }
            else if (difficulty == MainWindow.dif.hard)
            {
                cols = 24;
                rows = 20;
                mines = 99;
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

        public void setMines(int x, int y)
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
        }

    }
}
