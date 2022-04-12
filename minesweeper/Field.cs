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
        int adjacentMines;

        bool isChecked; // Used to prevent double-checking a field when checking for adjacent mines

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

        public bool IsChecked
        {
            get { return isChecked; }
            set { isChecked = value; }
        }

        public Field()
        {
            isMine = false;
            isRevealed = false;
            adjacentMines = 0;
            isChecked = false;
        }
    }
}
