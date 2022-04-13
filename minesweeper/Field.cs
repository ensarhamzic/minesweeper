using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace minesweeper
{
    internal class Field
    {
        bool isMine;
        bool isRevealed;
        bool isFlagged;
        int adjacentMines;


        public int AdjacentMines
        {
            get { return adjacentMines; }
            set { adjacentMines = value; }
        }

        public bool IsMine
        {
            get { return isMine; }
            set { isMine = value; }
        }

        public bool IsRevealed
        {
            get { return isRevealed; }
            set { isRevealed = value; }
        }


        public bool IsFlagged
        {
            get { return isFlagged; }
            set { isFlagged = value; }
        }

        public Field()
        {
            isMine = false;
            isRevealed = false;
            adjacentMines = 0;
            isFlagged = false;
        }
    }
}
