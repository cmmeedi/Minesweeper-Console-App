using System;
using System.Data.Common.CommandTrees.ExpressionBuilder;

namespace MileStone1
{
    public class Cell
    {

        public int row { get; set; }
        public int column { get; set; }
        //Visited will let you know if you have already checked the current cell for a bomb
        public bool visited { get; set; }
        //This is the Bomb cell.  True means there is a bomb in the cell
        public bool live { get; set; }
        //This indicates which cell next to the bomb will also have a bomb
        public int neighbor { get; set; }

        //This is the constructor that takes an argument for each of the attributes in the class
        public Cell(int row = -1, int column = -1, bool visited = false, bool live = false, int neighbor = 0)
        {
            this.row = row;
            this.column = column;
            this.visited = visited;
            this.live = live;
            this.neighbor = neighbor;
        }
    }
}
