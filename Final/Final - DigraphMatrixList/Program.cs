using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final___DigraphMatrixList
{
    internal class Program
    {
        private const int RedIndex = 0;
        private const int BlueIndex = 1;
        private const int GreyIndex = 2;
        private const int LightBlueIndex = 3;
        private const int OrangeIndex = 4;
        private const int PurpleIndex = 5;
        private const int YellowIndex = 6;
        private const int GreenIndex = 7;

        private const int WeightFloor = 0;


        private static string[] indexNames = { "red", "blue", "grey", "light blue", "orange", "purple", "yellow", "green" };

        static void Main(string[] args)
        {
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
             /* yellow */   {-1,     -1,    -1,  -1,         -1,     -1,     -1,     1 },
             /* green */    {-1,     -1,    -1,  -1,         -1,     -1,     -1,     -1 }

            };

            PrintAdjencyMatrix(digraphMatrix, indexNames);
            PrintAdjencancyList(digraphMatrix, indexNames);
            DepthFirstSearch(indexNames[RedIndex], digraphMatrix, indexNames);
            DijkstraShortestPath(indexNames[RedIndex], indexNames[GreenIndex], digraphMatrix, weights, indexNames);
            
        }

        public static void DijkstraShortestPath(string startColor, string endColor, bool[,] diagraphMatrix, int[,] matrixWeights, string[] indexNames)
        {
            List<int> lengths = new List<int>();
            List<string> visited = new List<string>();

            visited.Add(startColor);


            Console.WriteLine(ShortestPathRecursive(startColor, endColor, diagraphMatrix, matrixWeights, indexNames, visited, lengths));


        }

        public static int ShortestPathRecursive(string startColor, string endColor, bool[,] diagraphMatrix, int[,] matrixWeights, string[] indexNames, List<string> visited, List<int> lengths)
        {
            bool startingRecursion = false;

            if(visited.Count == 1)
            {
                startingRecursion = true;
            }

            if (startColor != endColor)
            {

                for (int j = 0; j < diagraphMatrix.GetLength(1); j++)
                {
                    if (diagraphMatrix[Array.IndexOf(indexNames, startColor), j] == true && !visited.Contains(indexNames[j]))
                    {
                        visited.Add(indexNames[j]);
                        lengths.Add(matrixWeights[Array.IndexOf(indexNames, startColor), j]);
                        lengths.Add(ShortestPathRecursive(startColor, endColor, diagraphMatrix, matrixWeights, indexNames, visited, lengths));
                    }
                }
            }

            if (startingRecursion)
            {
                return lengths.Max();
            }

            else
            {

                int finalLength = 0;
                foreach(int i in lengths)
                {
                    finalLength += i;
                }
                return finalLength;
            }
            


        }

        public static void DepthFirstSearch(string color, bool[,] diagraphMatrix, string[] indexNames)
        {

            Console.Write(DFSRecursive(new List<string>(), diagraphMatrix, indexNames, indexNames[RedIndex]));
        }

        public static string DFSRecursive(List<string> visited, bool[,] diagraphMatrix, string[] indexNames, string color)
        {
            string result = "";

            
                
            for (int j = 0; j < diagraphMatrix.GetLength(1); j++)
            {
                if (diagraphMatrix[Array.IndexOf(indexNames, color), j] == true && !visited.Contains(indexNames[j]))
                {
                    visited.Add(indexNames[j]);
                    result += (indexNames[j] + " " + DFSRecursive(visited, diagraphMatrix, indexNames, indexNames[j]));
                }
            }

            return result;
        }

        public static void PrintAdjencyMatrix(bool[,] diagraphMatrix, string[] indexNames)
        {
            int[,] result = new int[diagraphMatrix.GetLength(0), diagraphMatrix.GetLength(1)];

            for (int i = 0; i < diagraphMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < diagraphMatrix.GetLength(1); j++)
                {
                    if (diagraphMatrix[i,j] == false)
                    {
                        result[i, j] = 0;
                    }
                    else
                    {
                        result[i,j] = 1;
                    }
                }
            }

            int counter = 0;
            int limit = diagraphMatrix.GetLength(0);

            foreach(int i in result)
            {
                Console.Write(" " + i + " ");
                counter++;

                if(counter == limit)
                {
                    counter = 0;
                    Console.Write("\n");
                }
            }
        }

        public static void PrintAdjencancyList(bool[,] digraphMatrix, string[] indexNames)
        {
            string listResult;

            for (int i = 0; i < digraphMatrix.GetLength(0); i++)
            {

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