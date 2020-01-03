# Peg Solitaire
This program simulates a peg solitaire board and "solves" it, i.e. returns a sequential list of moves that will result in winning.

## Summary of Program's Purpose and Design


## Brief Peg Solitaire Explanation


## Explanation of Board Simulation


## Explanation of Solver Design


This program solves the game through an algorithm that which uses brute force random number guessing. 

I made a Node class that had two attributes: position (int) and empty (bool). Then, I made a Board class that has a list of 15 "holes" (Nodes) that can either be full or empty, and two dictionaries to keep track of adjacencies/distant adjacencies. The Board class has a few methods, but the most important is the Solve() method, which attempts to legally get the board down to one peg. It does this by making a LOT of lists that track other stuff, such as the number of full nodes, the full nodes adjacent to those nodes, and the distant empty neighbors to the original full nodes. Then, a lot of checks take place, and either a jump occurs or it doesn't, and if every possible jump is made with a board after so many turns, the board resets and starts over. The node that is chosen to ATTEMPT to jump is chosen by random. It's a headache and I'm really tired of this program.

Data structure: I used a graph. My graph was composed of three parts: a list of Nodes to represent ALL the pegs (and whether they were empty/full and what their position was) called nodeList, a dictionary with an int key and a List(Node) thing that represented each node's neighbors (their adjacent nodes), and a dictionary with an int key and a List(Node)) thing that represented each node's DISTANT neighbors (nodes that were directly two nodes away). I don't know how to exactly put that last dictionary into words, so I'll just show it, sort of:
```
nodeDistantNeighbors.Add(0, new List(Node))()); 
nodeDistantNeighbors[0].Add(nodeList[3]); //0 is distant neighbors with 3
nodeDistantNeighbors[0].Add(nodeList[5]); //0 is distant neighbors with 5
```
Check out [MarkdownText.md](https://github.com/kevin-dolan/peg-solitaire/blob/master/MarkdownTesting.md "MarkdownText.md") to see how I butcher markdown!