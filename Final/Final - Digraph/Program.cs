using System;
using System.Collections.Generic;
using System.Linq;

class DirectedGraph
{
    private Dictionary<string, int> vertexIndices;
    private List<List<Tuple<int, int>>> adjacencyList; // Tuple<int, int> represents vertex and weight

    public DirectedGraph()
    {
        this.vertexIndices = new Dictionary<string, int>();
        this.adjacencyList = new List<List<Tuple<int, int>>>();
    }

    public void AddVertex(string vertex)
    {
        if (!vertexIndices.ContainsKey(vertex))
        {
            int newIndex = vertexIndices.Count;
            vertexIndices[vertex] = newIndex;
            adjacencyList.Add(new List<Tuple<int, int>>());
        }
    }

    public void AddEdge(string from, string to, int weight)
    {
        int fromIndex = GetVertexIndex(from);
        int toIndex = GetVertexIndex(to);

        adjacencyList[fromIndex].Add(new Tuple<int, int>(toIndex, weight));
    }

    public void PrintAdjacencyMatrix()
    {
        Console.WriteLine("Adjacency Matrix:");
        foreach (var row in adjacencyList)
        {
            for (int i = 0; i < vertexIndices.Count; i++)
            {
                int weight = GetWeight(row, i);
                Console.Write($"{weight} ");
            }
            Console.WriteLine();
        }
    }

    public void PrintAdjacencyList()
    {
        Console.WriteLine("Adjacency List:");
        foreach (var kvp in vertexIndices)
        {
            int index = kvp.Value;
            Console.Write($"{kvp.Key} -> ");
            if (adjacencyList[index].Count > 0)
            {
                Console.Write(string.Join(", ", adjacencyList[index].Select(edge => $"{GetVertexName(edge.Item1)} ({edge.Item2})")));
            }
            Console.WriteLine();
        }
    }

    public void DFS(string startColor)
    {
        bool[] visited = new bool[adjacencyList.Count];
        List<int> path = new List<int>();
        DFSRecursive(GetVertexIndex(startColor), visited, path);
        Console.WriteLine(); // Add a new line after DFS output
    }

    public void DijkstraShortestPath(string startColor, string endColor)
    {
        int[] distances = new int[adjacencyList.Count];
        int[] previousVertices = new int[adjacencyList.Count];
        bool[] visited = new bool[adjacencyList.Count];

        for (int i = 0; i < adjacencyList.Count; i++)
        {
            distances[i] = int.MaxValue;
        }

        int startIndex = GetVertexIndex(startColor);
        int endIndex = GetVertexIndex(endColor);

        distances[startIndex] = 0;

        for (int i = 0; i < adjacencyList.Count - 1; i++)
        {
            int u = MinDistance(distances, visited);
            visited[u] = true;

            foreach (var neighbor in adjacencyList[u])
            {
                int v = neighbor.Item1;
                int weight = neighbor.Item2;

                if (!visited[v] && distances[u] != int.MaxValue && distances[u] + weight < distances[v])
                {
                    distances[v] = distances[u] + weight;
                    previousVertices[v] = u;
                }
            }
        }

        PrintShortestPath(startColor, endColor, distances, previousVertices);
    }

    private void PrintShortestPath(string startColor, string endColor, int[] distances, int[] previousVertices)
    {
        int startIndex = GetVertexIndex(startColor);
        int endIndex = GetVertexIndex(endColor);

        Console.WriteLine($"Shortest path from {startColor} to {endColor}:");

        if (distances[endIndex] == int.MaxValue)
        {
            Console.WriteLine("No path found.");
            return;
        }

        List<string> path = new List<string>();
        int currentVertex = endIndex;

        while (currentVertex != startIndex)
        {
            path.Add(GetVertexName(currentVertex));
            currentVertex = previousVertices[currentVertex];
        }

        path.Add(startColor);
        path.Reverse();

        Console.Write(string.Join(" -> ", path));
        Console.WriteLine($"\nTotal distance: {distances[endIndex]}");
    }

    private int MinDistance(int[] distances, bool[] visited)
    {
        int min = int.MaxValue;
        int minIndex = -1;

        for (int v = 0; v < adjacencyList.Count; v++)
        {
            if (!visited[v] && distances[v] <= min)
            {
                min = distances[v];
                minIndex = v;
            }
        }

        return minIndex;
    }


    private void PrintShortestPathRecursive(int currentIndex, int[] distances)
    {
        List<int> path = new List<int>();

        while (currentIndex != -1)
        {
            path.Add(currentIndex);
            currentIndex = GetPreviousVertex(currentIndex, distances);
        }

        path.Reverse();

        foreach (var index in path)
        {
            Console.Write($"{GetVertexName(index)} ");
        }
    }

    private int GetPreviousVertex(int currentIndex, int[] distances)
    {
        int minDistance = int.MaxValue;
        int previousVertex = -1;

        foreach (var neighbor in adjacencyList[currentIndex])
        {
            if (distances[neighbor.Item1] < minDistance)
            {
                minDistance = distances[neighbor.Item1];
                previousVertex = neighbor.Item1;
            }
        }

        return previousVertex;
    }

    private void DFSRecursive(int node, bool[] visited, List<int> path)
    {
        if (visited[node])
            return;

        Console.Write($"{GetVertexName(node)} ");
        visited[node] = true;
        path.Add(node);

        foreach (var neighbor in adjacencyList[node])
        {
            if (!visited[neighbor.Item1])
            {
                DFSRecursive(neighbor.Item1, visited, path);
            }
            else if (path.Contains(neighbor.Item1) && path.Count <= 1)
            {
                // Handle self-loops or duplicate edges
                Console.WriteLine($"Cycle detected: {GetVertexName(node)} -> {GetVertexName(neighbor.Item1)}");
            }
        }

        path.Remove(node);
    }

    private int GetVertexIndex(string vertex)
    {
        if (vertexIndices.ContainsKey(vertex))
        {
            return vertexIndices[vertex];
        }
        return -1; // Vertex not found
    }

    private string GetVertexName(int index)
    {
        return vertexIndices.FirstOrDefault(x => x.Value == index).Key;
    }

    private int GetWeight(List<Tuple<int, int>> row, int columnIndex)
    {
        var edge = row.FirstOrDefault(t => t.Item1 == columnIndex);
        return edge != null ? edge.Item2 : 0;
    }
}

class Program
{
    private const int RedIndex = 0;
    private const int BlueIndex = 1;
    private const int GreyIndex = 2;
    private const int LightBlueIndex = 3;
    private const int OrangeIndex = 4;
    private const int PurpleIndex = 5;
    private const int YellowIndex = 6;
    private const int GreenIndex = 7;


    private string[] indexNames = { "red", "blue", "grey", "light blue", "orange", "purple", "yellow", "green" };

    static void Main()
    {
        bool[,] digraphMatrix = new bool[,]
        {
                   // red   blue  grey  light blue orange purple yellow green
       /* red */   { false, true, true, false ,    false, false, false, false},
       /* blue */  { false, false, true, false ,    false, false, true, false},
       /* grey */  { false, false, false, true ,    true, false, false, false},
       /* l.blue */{ false, true, true, false ,    false, false, false, false},
       /* orange */{ false, false, false, false ,    false, true, false, false},
       /* purple */{ false, false, false, false ,    false, false, true, false},
       /* yellow */{ false, false, false, false ,    false, false, false, true},
       /* green */ { false, false, false, false ,    false, false, false, false}
        };

        Print
        

    }

    public void PrintAdjencancyList(bool[,] matrix)
    {
        string listResult;

        for(int i = 0; i < matrix.GetLength(0); i++)
        {

            if (i == RedIndex)
            {
                listResult = this.indexNames[RedIndex] + " ->";
            }
            else if (i == BlueIndex)
            {
                listResult = this.indexNames[BlueIndex] + " ->";
            }
            else if (i == GreyIndex)
            {
                listResult = this.indexNames[GreyIndex] + " ->";
            }
            else if (i == LightBlueIndex)
            {
                listResult = this.indexNames[LightBlueIndex] + " ->";
            }
            else if (i == OrangeIndex)
            {
                listResult = this.indexNames[OrangeIndex] + " ->";
            }
            else if (i == PurpleIndex)
            {
                listResult = this.indexNames[PurpleIndex] + " ->";
            }
            else if (i == YellowIndex)
            {
                listResult = this.indexNames[YellowIndex] + " ->";
            }
            else
            {
                listResult = this.indexNames[GreenIndex] + " ->";
            }

            for (int j = 0; j < matrix.GetLength(1); j++)
            {

                if (matrix[i,j] == true)
                {
                    listResult += " " + this.indexNames[j];
                }


            }

            Console.WriteLine(listResult);

        }
    }
}


    
