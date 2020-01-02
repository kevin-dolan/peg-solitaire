using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW5KDolan
{
    /* Program Name: HW5KDolan or Data Structures
     * Programmers: Kevin Dolan
     * Description: Peg Game solver. Pain. Pain.
     * Instructor: Prof. Bierre
     * Class: IGME 106
     */
    class Node
    {
        //attibutes
        private int position; //this is storing where on the board this node is
        private bool empty; //keep track of whether this node is empty/full

        //properties
        public int Position
        {
            get { return position; } //DEFINITELY don't want the position to change after it's been instantiated, so there's only a get-property
        }
        public bool Empty
        {
            get { return empty; }
            set { empty = value; }
        }

        //constructor
        public Node(int pos)
        {
            position = pos;
            empty = false; //"full" by default
        }

        public override string ToString()
        {
            return "Pos: " + position + " Emp: " + empty;
        }
    }
}
