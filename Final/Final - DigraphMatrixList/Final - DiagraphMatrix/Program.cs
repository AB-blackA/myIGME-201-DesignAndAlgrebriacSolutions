using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* Program: Final - DigraphMatrixList
 * Purpose: Console virtual interpretation of a Digraph graph, complete with functionality for displaying information
 * about possible travel paths, weights, edges, and shortest path to a destination. As per IGME201's Final Test 
 */
namespace Final___DigraphMatrix
{
    internal class Program
    {
        //constants for color indexing to matrices
        private const int RedIndex = 0;
        private const int BlueIndex = 1;
        private const int GreyIndex = 2;
        private const int LightBlueIndex = 3;
        private const int OrangeIndex = 4;
        private const int PurpleIndex = 5;
        private const int YellowIndex = 6;
        private const int GreenIndex = 7;

        //unused constant that is used for our weight matrice; anything less than 0 represents there is no connection
        private const int WeightFloor = 0;

        //index of strings. static to be used with methods outside of main
        private static string[] indexNames = { "red", "blue", "grey", "light blue", "orange", "purple", "yellow", "green" };

        /* Method: Main
         * Purpose: Run test data for final exam regarding Diagraph Matrices
         */
        static void Main(string[] args)
        {

            //create matrix based on specifications added in final exam. Indexed for your viewing pleasure
            bool[,] digraphMatrix = new bool[,]
            {
                           // red   blue  grey  light blue orange purple yellow green
               /* red */   { false, true, true, false ,    false, false, false, false},
               /* blue */  { false, false, false, true ,    false, false, true, false},
               /* grey */  { false, false, false, true ,    true, false, false, false},
               /* l.blue */{ false, true, true, false ,    false, false, false, false},
               /* orange */{ false, false, false, false ,    false, true, false, false},
               /* purple */{ false, false, false, false ,    false, false, true, false},
               /* yellow */{ false, false, false, false ,    false, false, false, true},
               /* green */ { false, false, false, false ,    false, false, false, false}
            };

            //our weights for our diagraphMatrix. recall that anything lower than the WeightFLoor (-1)
            //indicates that there is no edge
            int[,] weights = new int[,]
            {
                            // red   blue  grey  light blue orange purple yellow green
             /* red */      {-1,     1 ,    5,  -1,         -1,     -1,     -1,     -1  },
             /* blue */     {-1,     -1,    -1,  1,         -1,     -1,     8, -    1 },
             /* grey */     {-1,     -1,    -1,  0,         1,      -1,     -1,     -1 },
             /* l.blue */   {-1,     1,     0,  -1,         -1,     -1,     -1,     -1 },
             /* orange */   {-1,     -1,    -1,  -1,         -1,     1,     -1,     -1 },
             /* purple */   {-1,     -1,    -1,  -1,         -1,     -1,     1,     -1 },
             /* yellow */   {-1,     -1,    -1,  -1,         -1,     -1,     -1,     6 },
             /* green */    {-1,     -1,    -1,  -1,         -1,     -1,     -1,     -1 }

            };

            //call functions to output to console various tasks done on the data using the matrices
            PrintAdjencyMatrix(digraphMatrix, indexNames);
            PrintAdjencancyList(digraphMatrix, indexNames);
            DepthFirstSearch(indexNames[RedIndex], digraphMatrix, indexNames);
            DijkstraShortestPath(indexNames[RedIndex], indexNames[GreenIndex], digraphMatrix, weights, indexNames);

        }

        /* Method: DijkstraShortestPath
         * Purpose: Finds the shortest path from one vertice to another. Mostly relies on a recursive function to do the work
         */
        public static void DijkstraShortestPath(string startColor, string endColor, bool[,] diagraphMatrix, int[,] matrixWeights, string[] indexNames)
        {
            List<int> lengths = new List<int>();
            List<string> visited = new List<string>();

            visited.Add(startColor);

            //call recursive function
            Console.WriteLine(ShortestPathRecursive(startColor, endColor, diagraphMatrix, matrixWeights, indexNames, visited));

        }

        /* Method: ShortestPathRecursive
         * Purpose: Recursively finds the shortest path based on starting color, ending color, the matrices, color names, and list of colors already visited by this current path
         */
        public static int ShortestPathRecursive(string startColor, string endColor, bool[,] diagraphMatrix, int[,] matrixWeights, string[] indexNames, List<string> visited)
        {

            //base case where we have reached our destination
            if (startColor == endColor)
            {
                //no more edges; return length of zero
                return 0;
            }

            // Initialize to a large value. Such a large value is WAY outside the scope of data, so we can use this to check for a dead end later
            int minLength = int.MaxValue;

            //iterate through matrix
            for (int j = 0; j < diagraphMatrix.GetLength(1); j++)
            {
                //if we find a path and that color hasn't been reached already, continue 
                if (diagraphMatrix[Array.IndexOf(indexNames, startColor), j] == true && !visited.Contains(indexNames[j]))
                {
                    //add reached color to the visited array
                    visited.Add(indexNames[j]);

                    //add the weight for that path, and look for more paths by recalling this function (noting to change the startColor to the new color on the path)
                    int currentLength = matrixWeights[Array.IndexOf(indexNames, startColor), j] +
                                        ShortestPathRecursive(indexNames[j], endColor, diagraphMatrix, matrixWeights, indexNames, visited);

                    //change minLength to whatever is smaller - its MaxValue or the current length. Recall that if any future path isn't found, a MaxValue will be set 
                    //to minLength therefor an "impossible path" returns that highly absurd number to notify there was no usable path. 
                    minLength = Math.Min(minLength, currentLength);

                    //backtrack by removing the last visited node
                    visited.Remove(indexNames[j]);
                }
            }

            //return zero if minLength wasn't changed from its maxvalue; otherwise, return the minimum length found to complete the path
            return minLength == int.MaxValue ? 0 : minLength;
        }

        /* Method: DepthFirstSearch
         * Purpose: Calls the function DFSRecursive which recursively finds a Depth First Search of a vertice
         */
        public static void DepthFirstSearch(string color, bool[,] diagraphMatrix, string[] indexNames)
        {

            Console.Write(DFSRecursive(new List<string>(), diagraphMatrix, indexNames, indexNames[RedIndex]));
        }

        /* Method: DFSRecursive
         * Purpose: Recusrively does a Depth First Search of a vertice by keeping track of vertices already visited 
         */
        public static string DFSRecursive(List<string> visited, bool[,] diagraphMatrix, string[] indexNames, string color)
        {

            //what will be returned eventually is an addition of colors to this string, as long as we can reach those colors
            string result = "";

            //loop through graph and determine if there's an edge (and that edge doesn't go to a color already visited)
            for (int j = 0; j < diagraphMatrix.GetLength(1); j++)
            {
                if (diagraphMatrix[Array.IndexOf(indexNames, color), j] == true && !visited.Contains(indexNames[j]))
                {
                    //if its a new color, add it to the visited list and look for more paths to unique colors 
                    visited.Add(indexNames[j]);
                    result += (indexNames[j] + " " + DFSRecursive(visited, diagraphMatrix, indexNames, indexNames[j]));
                }
            }

            return result;
        }

        /* Method: PrintAdjencyMatrix
         * Purpose: Prints a visual representation of the available edges from the diagraphMatrix to the console
         */
        public static void PrintAdjencyMatrix(bool[,] diagraphMatrix, string[] indexNames)
        {
            //clone the size of the diagraphMatrix into an int 2D matrix
            int[,] result = new int[diagraphMatrix.GetLength(0), diagraphMatrix.GetLength(1)];

            //if there is an edge, add a 1 to result to indicate so. otherwise, add 0
            for (int i = 0; i < diagraphMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < diagraphMatrix.GetLength(1); j++)
                {
                    if (diagraphMatrix[i, j] == false)
                    {
                        result[i, j] = 0;
                    }
                    else
                    {
                        result[i, j] = 1;
                    }
                }
            }

            //print to console the new result matrix
            int counter = 0;
            int limit = diagraphMatrix.GetLength(0);

            foreach (int i in result)
            {
                Console.Write(" " + i + " ");
                counter++;

                if (counter == limit)
                {
                    counter = 0;
                    Console.Write("\n");
                }
            }
        }

        /* Method: PrintAdjencancyList
         * Purpose: Print which Vertices are connected to one another by looking through the diagraphMatrix and printint the color
         * of any vertice that has an edge to another
         */
        public static void PrintAdjencancyList(bool[,] digraphMatrix, string[] indexNames)
        {
            //string to be printed
            string listResult;

            //loop through columns of diagraphMatrix
            for (int i = 0; i < digraphMatrix.GetLength(0); i++)
            {

                //for each color, start its output statement
                if (i == RedIndex)
                {
                    listResult = indexNames[RedIndex] + " ->";
                }
                else if (i == BlueIndex)
                {
                    listResult = indexNames[BlueIndex] + " ->";
                }
                else if (i == GreyIndex)
                {
                    listResult = indexNames[GreyIndex] + " ->";
                }
                else if (i == LightBlueIndex)
                {
                    listResult = indexNames[LightBlueIndex] + " ->";
                }
                else if (i == OrangeIndex)
                {
                    listResult = indexNames[OrangeIndex] + " ->";
                }
                else if (i == PurpleIndex)
                {
                    listResult = indexNames[PurpleIndex] + " ->";
                }
                else if (i == YellowIndex)
                {
                    listResult = indexNames[YellowIndex] + " ->";
                }
                else
                {
                    listResult = indexNames[GreenIndex] + " ->";
                }

                //then loop through each row of the diagraphMatrix, looking for any true values. If so, add that color onto its result statement
                for (int j = 0; j < digraphMatrix.GetLength(1); j++)
                {

                    if (digraphMatrix[i, j] == true)
                    {
                        listResult += " " + indexNames[j];
                    }


                }

                Console.WriteLine(listResult);

            }
        }
    }


}
