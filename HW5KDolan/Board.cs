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
    //Game Plan: brute force it
    //Attempt to solve by linearly guessing a solution until Win() returns true for each hole position
    class Board
    {
        //attributes
        int hole; //keep track of what the starting hole is when you begin jumping
        Random randy;
        List<string> moves; //keep track of all the moves made in a successful run
        List<Node> nodeList; //list of all the spots on the board
        Dictionary<int, List<Node>> nodeNeighbors; //list of each node's neighbor, or adjacent node
        Dictionary<int, List<Node>> nodeDistantNeighbors; //list of each node's neighbor *two* nodes away 

        // constructor
        public Board(int h)
        {
            moves = new List<string>();
            randy = new Random();
            //make the list and dictionaries
            nodeList = new List<Node>();
            nodeNeighbors = new Dictionary<int, List<Node>>();
            nodeDistantNeighbors = new Dictionary<int, List<Node>>();

            // populate the Node list by looping (you guessed it) 15 times
            for (int i = 0; i < 15; i++)
            {
                nodeList.Add(new Node(i));
            }

            hole = h; //the empty hole is assigned via the passed in int from the constructor
            nodeList[hole].Empty = true;

            //create the neighbors list by manually instantiating them by hand
            nodeNeighbors.Add(0, new List<Node>());
            nodeNeighbors[0].Add(nodeList[1]); //0 is next to 1
            nodeNeighbors[0].Add(nodeList[2]); //0 is next to 2

            nodeNeighbors.Add(1, new List<Node>());
            nodeNeighbors[1].Add(nodeList[0]); //1 is next to 0
            nodeNeighbors[1].Add(nodeList[2]); //1 is next to 2
            nodeNeighbors[1].Add(nodeList[4]); //1 is next to 4
            nodeNeighbors[1].Add(nodeList[3]); //1 is next to 3

            nodeNeighbors.Add(2, new List<Node>());
            nodeNeighbors[2].Add(nodeList[5]); //2 is next to 5
            nodeNeighbors[2].Add(nodeList[4]); //2 is next to 4
            nodeNeighbors[2].Add(nodeList[1]); //2 is next to 1
            nodeNeighbors[2].Add(nodeList[0]); //2 is next to 0

            nodeNeighbors.Add(3, new List<Node>());
            nodeNeighbors[3].Add(nodeList[1]); //3 is next to 1
            nodeNeighbors[3].Add(nodeList[4]); //3 is next to 4
            nodeNeighbors[3].Add(nodeList[7]); //3 is next to 7
            nodeNeighbors[3].Add(nodeList[6]); //3 is next to 6

            nodeNeighbors.Add(4, new List<Node>());
            nodeNeighbors[4].Add(nodeList[2]); //4 is next to 2
            nodeNeighbors[4].Add(nodeList[5]); //4 is next to 5
            nodeNeighbors[4].Add(nodeList[8]); //4 is next to 8
            nodeNeighbors[4].Add(nodeList[7]); //4 is next to 7
            nodeNeighbors[4].Add(nodeList[3]); //4 is next to 3
            nodeNeighbors[4].Add(nodeList[1]); //4 is next to 1

            nodeNeighbors.Add(5, new List<Node>());
            nodeNeighbors[5].Add(nodeList[9]); //5 is next to 9
            nodeNeighbors[5].Add(nodeList[8]); //5 is next to 8
            nodeNeighbors[5].Add(nodeList[4]); //5 is next to 4
            nodeNeighbors[5].Add(nodeList[2]); //5 is next to 2

            nodeNeighbors.Add(6, new List<Node>());
            nodeNeighbors[6].Add(nodeList[3]); //6 is next to 3
            nodeNeighbors[6].Add(nodeList[7]); //6 is next to 7
            nodeNeighbors[6].Add(nodeList[11]); //6 is next to 11
            nodeNeighbors[6].Add(nodeList[10]); //6 is next to 10

            nodeNeighbors.Add(7, new List<Node>());
            nodeNeighbors[7].Add(nodeList[4]); //7 is next to 4
            nodeNeighbors[7].Add(nodeList[8]); //7 is next to 8
            nodeNeighbors[7].Add(nodeList[12]); //7 is next to 12
            nodeNeighbors[7].Add(nodeList[11]); //7 is next to 11
            nodeNeighbors[7].Add(nodeList[6]); //7 is next to 6
            nodeNeighbors[7].Add(nodeList[3]); //7 is next to 3

            nodeNeighbors.Add(8, new List<Node>());
            nodeNeighbors[8].Add(nodeList[5]); //8 is next to 5
            nodeNeighbors[8].Add(nodeList[9]); //8 is next to 9
            nodeNeighbors[8].Add(nodeList[13]); //8 is next to 13
            nodeNeighbors[8].Add(nodeList[12]); //8 is next to 12
            nodeNeighbors[8].Add(nodeList[7]); //8 is next to 7
            nodeNeighbors[8].Add(nodeList[4]); //8 is next to 4

            nodeNeighbors.Add(9, new List<Node>());
            nodeNeighbors[9].Add(nodeList[14]); //9 is next to 14
            nodeNeighbors[9].Add(nodeList[13]); //9 is next to 13
            nodeNeighbors[9].Add(nodeList[8]); //9 is next to 8
            nodeNeighbors[9].Add(nodeList[5]); //9 is next to 5

            nodeNeighbors.Add(10, new List<Node>());
            nodeNeighbors[10].Add(nodeList[6]); //10 is next to 6
            nodeNeighbors[10].Add(nodeList[11]); //10 is next to 11

            nodeNeighbors.Add(11, new List<Node>());
            nodeNeighbors[11].Add(nodeList[7]); //11 is next to 7
            nodeNeighbors[11].Add(nodeList[12]); //11 is next to 12
            nodeNeighbors[11].Add(nodeList[10]); //11 is next to 10
            nodeNeighbors[11].Add(nodeList[6]); //11 is next to 6

            nodeNeighbors.Add(12, new List<Node>());
            nodeNeighbors[12].Add(nodeList[8]); //12 is next to 8
            nodeNeighbors[12].Add(nodeList[13]); //12 is next to 13
            nodeNeighbors[12].Add(nodeList[11]); //12 is next to 11
            nodeNeighbors[12].Add(nodeList[7]); //12 is next to 7

            nodeNeighbors.Add(13, new List<Node>());
            nodeNeighbors[13].Add(nodeList[9]); //13 is next to 9
            nodeNeighbors[13].Add(nodeList[14]); //13 is next to 14
            nodeNeighbors[13].Add(nodeList[12]); //13 is next to 12
            nodeNeighbors[13].Add(nodeList[8]); //13 is next to 8

            nodeNeighbors.Add(14, new List<Node>());
            nodeNeighbors[14].Add(nodeList[9]); //14 is next to 9
            nodeNeighbors[12].Add(nodeList[13]); //14 is next to 13


            //create the distant neighbors list by also manually instantiating them by hand
            nodeDistantNeighbors.Add(0, new List<Node>());
            nodeDistantNeighbors[0].Add(nodeList[3]); //0 is distant neighbors with 3
            nodeDistantNeighbors[0].Add(nodeList[5]); //0 is distant neighbors with 5


            nodeDistantNeighbors.Add(1, new List<Node>());
            nodeDistantNeighbors[1].Add(nodeList[6]); //1 is distant neighbors with 6
            nodeDistantNeighbors[1].Add(nodeList[8]); //ok i'm done with writing this for every single addition

            nodeDistantNeighbors.Add(2, new List<Node>());
            nodeDistantNeighbors[2].Add(nodeList[7]);
            nodeDistantNeighbors[2].Add(nodeList[9]);

            nodeDistantNeighbors.Add(3, new List<Node>());
            nodeDistantNeighbors[3].Add(nodeList[0]);
            nodeDistantNeighbors[3].Add(nodeList[5]);
            nodeDistantNeighbors[3].Add(nodeList[12]);
            nodeDistantNeighbors[3].Add(nodeList[10]);

            nodeDistantNeighbors.Add(4, new List<Node>());
            nodeDistantNeighbors[4].Add(nodeList[13]);
            nodeDistantNeighbors[4].Add(nodeList[11]);

            nodeDistantNeighbors.Add(5, new List<Node>());
            nodeDistantNeighbors[5].Add(nodeList[14]);
            nodeDistantNeighbors[5].Add(nodeList[12]);
            nodeDistantNeighbors[5].Add(nodeList[3]);
            nodeDistantNeighbors[5].Add(nodeList[0]);

            nodeDistantNeighbors.Add(6, new List<Node>());
            nodeDistantNeighbors[6].Add(nodeList[1]);
            nodeDistantNeighbors[6].Add(nodeList[8]);

            nodeDistantNeighbors.Add(7, new List<Node>());
            nodeDistantNeighbors[7].Add(nodeList[2]);
            nodeDistantNeighbors[7].Add(nodeList[9]);

            nodeDistantNeighbors.Add(8, new List<Node>());
            nodeDistantNeighbors[8].Add(nodeList[6]);
            nodeDistantNeighbors[8].Add(nodeList[1]);

            nodeDistantNeighbors.Add(9, new List<Node>());
            nodeDistantNeighbors[9].Add(nodeList[7]);
            nodeDistantNeighbors[9].Add(nodeList[2]);

            nodeDistantNeighbors.Add(10, new List<Node>());
            nodeDistantNeighbors[10].Add(nodeList[3]);
            nodeDistantNeighbors[10].Add(nodeList[12]);

            nodeDistantNeighbors.Add(11, new List<Node>());
            nodeDistantNeighbors[11].Add(nodeList[4]);
            nodeDistantNeighbors[11].Add(nodeList[13]);

            nodeDistantNeighbors.Add(12, new List<Node>());
            nodeDistantNeighbors[12].Add(nodeList[5]);
            nodeDistantNeighbors[12].Add(nodeList[14]);
            nodeDistantNeighbors[12].Add(nodeList[10]);
            nodeDistantNeighbors[12].Add(nodeList[3]);

            nodeDistantNeighbors.Add(13, new List<Node>());
            nodeDistantNeighbors[13].Add(nodeList[4]);
            nodeDistantNeighbors[13].Add(nodeList[11]);

            nodeDistantNeighbors.Add(14, new List<Node>());
            nodeDistantNeighbors[14].Add(nodeList[12]);
            nodeDistantNeighbors[14].Add(nodeList[5]);
            //i hate this code and myself so much
        }

        //this was a test method to make sure my Win() method worked. you can ignore it.
        public string Rigged()
        {
            while (Win() == false) //loop until you win
            {
                for (int i = 0; i < 14; i++)
                {
                    nodeList[i].Empty = true;
                }
            }

            string ggEz = "gg ez";

            return ggEz;
        }

        public List<string> Solve()
        {
            List<Node> fullNodes = new List<Node>(); //create a list of all potential nodes capable of moving
            List<Node> attemptedNodes = new List<Node>(); //this list is for keeping track of which nodes no full neighboring nodes

            while (Win() == false) //loop until you win
            {
                

                if (attemptedNodes.Count >= 14 || fullNodes.Count == 1) //if every full node has been tried and no jump has been made OR a really weird scenario happened (don't ask), it's time to start over.
                {
                    Reset(); //rip
                    attemptedNodes.Clear();
                }

                fullNodes.Clear(); //clear it out at the beginning each time so that it can be set up from scratch every loop

                for (int i = 0; i <nodeList.Count; i ++) //in order to move, a node must have a peg in it TO move
                {
                    if (nodeList[i].Empty == false) //if full
                    {
                        if (attemptedNodes.Contains(nodeList[i]) == false) //if n is NOT a previously failed node
                        {
                            fullNodes.Add(nodeList[i]);
                        }
                    }
                }

                Node someFullNode = fullNodes[randy.Next(fullNodes.Count)]; //choose a random full node from the list of full nodes. now we got a full node

                List<Node> adjFullNodes = new List<Node>(); //its neighbor must be full
                for (int i = 0; i < nodeNeighbors[someFullNode.Position].Count; i++) //loop through the neighbors of the full node
                {
                    List<Node> temp = nodeNeighbors[someFullNode.Position]; //make a temp list of nodes to hold onto the list of neighbors to the full node

                    for (int j = 0; j < temp.Count; j++) //loop through the neighbors
                    {
                        if (temp[j].Empty == false) //if the neighbor node is full,
                        {
                            adjFullNodes.Add(temp[j]); //add it to the adjFullNodes list
                        }
                    }
                }
                //we got a list of all the neighboring full nodes to the first full node, if they exist

                List<Node> distEmptyNodes = new List<Node>(); //its distant neighbor must be empty
                for (int i = 0; i < nodeDistantNeighbors[someFullNode.Position].Count; i++) //loop through the distant neighbors of the full node
                {
                    List<Node> distTemp = nodeDistantNeighbors[someFullNode.Position]; //holding list<node> of 
                    for (int j = 0; j < distTemp.Count; j++) //loop through the distant neighbors
                    {
                        if (distTemp[j].Empty == true) //if distant neighbor is EMPTY,
                        {
                            distEmptyNodes.Add(distTemp[j]); //add it to the distEmptyNodes list
                        }
                    }
                }
                //we got a list of all the distant empty neigboring nodes to the first full node, if they exist

                //**********************************************************************************************************************************
                //i have a full node. i MGIHT have a list of adjacent full nodes to that node. i MIGHT have a list of distant empty nodes. okay.
                //**********************************************************************************************************************************
                bool jumped = false; //false by default
                if (adjFullNodes.Count > 0 && distEmptyNodes.Count > 0) //if there is at least one adjacent full node and one distant empty node,
                {
                    for (int i = 0; i < distEmptyNodes.Count; i++)
                    {
                        for (int j = 0; j < adjFullNodes.Count; j++)
                        {
                            //if adjFullNodes[j] is a neigboring node to distEmptyNodes[i], 
                            //(it took me 1-2 hours discover any pattern between a node and its distant neighbor: they have mutually excluse adjacent neighbors ***WITH ONE EXCEPTION***!)
                            if (nodeNeighbors[distEmptyNodes[i].Position].Contains(adjFullNodes[j]) == true) //hell is real and this line of code is inscribed on its gate
                            {
                                //jump
                                Jump(someFullNode.Position, adjFullNodes[j].Position, distEmptyNodes[i].Position);
                                attemptedNodes.Clear(); //new board, new batch of attempted nodes to try
                                i = distEmptyNodes.Count; //this line is a stupid workaround for a problem with my code I can't solve otherwise. without this line, my program jumps twice every time it gets to this loop because of the nature of the twice-nested for-loop. BAD PROGRAMMING!!!
                                jumped = true; //if you jump, set jumped to true
                                break;
                            }
                        }
                    }
                    if(jumped == false)
                    {
                        attemptedNodes.Add(someFullNode);
                    }
                }
                else
                {
                    attemptedNodes.Add(someFullNode);
                }
                //the hoops (LOOPS!!!!) i have made for myself to jump through are numerous and daunting
            }

            List<string> g = new List<string>();
            g.Add("=========================");
            g.Add("Position done: " + hole );
            g.Add("Pegs left: 1");
            g.Add("Moves: ");

            for (int i = 0; i < moves.Count; i++)
            {
                g.Add(moves[i]); //hope this formatting works
            }

            return g;
        }

        public void Jump(int beginning, int middle, int end)
        {
            //I originally included the middle node that was jumped over in the string, but realized that it was not needed to show the move.
            moves.Add("From " + beginning + " to " + end); //add the move that resulted in this jump to List<string> moves
            nodeList[beginning].Empty = true;
            nodeList[middle].Empty = true;
            nodeList[end].Empty = false;
            //from full, full, empty
            //to empty, empty, full
        }

        public void Reset()
        {
            // loop through all vertices
            for (int i = 0; i < nodeList.Count; i++)
            {
                nodeList[i].Empty = false;
            }
            nodeList[hole].Empty = true; //set the original hole to empty again
            moves.Clear();
        }

        //check if the board is cleared
        public bool Win()
        {
            int thereCanBeOnly = 0;

            for (int i = 0; i < nodeList.Count; i++)
            {
                if (nodeList[i].Empty == false) //if node is not empty (full)
                {
                    thereCanBeOnly++;
                }
                
            }

            if (thereCanBeOnly >= 2)
            {
                return false;
            }

            return true; //if you make it out of the for-loop by meeting a value for thereCanBeOnly, you win
        }
    }
}

