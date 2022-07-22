using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AllDataStructures.Sorting
{
    public class Sort
    {
        // swap
        public int[] Bubble(int[] array)
        {
            int length = array.Length;
            int temp = array[0];
            for (int i = 0; i < length; i++)
            {
                for (int j = i + 1; j < length; j++)
                {
                    if (array[i] > array[j])
                    {
                        temp = array[i];
                        array[i] = array[j];
                        array[j] = temp;
                    }
                }
            }

            return array;
        }

        // inserting
        public int[] Inserted(int[] intArray)
        {
            int temp, j;

            for (int i = 1; i < intArray.Length; i++)
            {
                temp = intArray[i];
                j = i - 1;
                while (j >= 0 && intArray[j] > temp)
                {
                    intArray[j + 1] = intArray[j];
                    j--;
                }
                intArray[j + 1] = temp;
            }


            return intArray;
        }

        // temp array
        public int[] Selection(int[] data)
        {

            int smallest;
            for (int i = 0; i < data.Length - 1; i++)
            {
                smallest = i;

                for (int index = i + 1; index < data.Length; index++)
                {
                    if (data[index] < data[smallest])
                    {
                        smallest = index;
                    }
                }
                int temporary = data[i];
                data[i] = data[smallest];
                data[smallest] = temporary;

            }
            return data;
        }

        // divide and rule
        public void Merge(int[] numbers, int left, int mid, int right)
        {
            int[] temp = new int[25];
            int i, left_end, num_elements, tmp_pos;
            left_end = (mid - 1);
            tmp_pos = left;
            num_elements = (right - left + 1);
            while ((left <= left_end) && (mid <= right))
            {
                if (numbers[left] <= numbers[mid])
                    temp[tmp_pos++] = numbers[left++];
                else
                    temp[tmp_pos++] = numbers[mid++];
            }

            while (left <= left_end)
                temp[tmp_pos++] = numbers[left++];
            while (mid <= right)
                temp[tmp_pos++] = numbers[mid++];
            for (i = 0; i < num_elements; i++)
            {
                numbers[right] = temp[right];
                right--;
            }
        }
        public void MergeDivide(int[] numbers, int left, int right)
        {
            int mid;
            if (right > left)
            {
                mid = (right + left) / 2;
                MergeDivide(numbers, left, mid); // left hand side
                MergeDivide(numbers, (mid + 1), right); // right hand side
                Merge(numbers, left, (mid + 1), right); // merging
            }
        }


    }
    public class QuickSort
    {
        public int Partition(int[] array, int low,
                                        int high)
        {
            //1. Select a pivot point.
            int pivot = array[high];

            int lowIndex = (low - 1);

            //2. Reorder the collection.
            for (int j = low; j < high; j++)
            {
                if (array[j] <= pivot)
                {
                    lowIndex++;

                    int temp = array[lowIndex];
                    array[lowIndex] = array[j];
                    array[j] = temp;
                }
            }

            int temp1 = array[lowIndex + 1];
            array[lowIndex + 1] = array[high];
            array[high] = temp1;

            return lowIndex + 1;
        }

        public void Sort(int[] array, int low, int high)
        {
            if (low < high)
            {
                int partitionIndex = Partition(array, low, high);

                //3. Recursively continue sorting the array
                Sort(array, low, partitionIndex - 1);
                Sort(array, partitionIndex + 1, high);
            }
        }
    }

    public  class Dijkstra
    {
        public  List<int> DijkstraAlgorithm(int[,] graph, int sourceNode, int destinationNode)
        {
            var n = graph.GetLength(0);

            var distance = new int[n];
            // all nodes are infinite
            for (int i = 0; i < n; i++)
            {
                distance[i] = int.MaxValue;
            }
            // start node
            distance[sourceNode] = 0;

            // array nodes visited boolean
            var used = new bool[n];
            var previous = new int?[n];

            while (true)
            {
                var minDistance = int.MaxValue;
                var minNode = 0;
                for (int i = 0; i < n; i++)
                {
                    if (!used[i] && minDistance > distance[i])
                    {
                        minDistance = distance[i];
                        minNode = i;
                    }
                }

                if (minDistance == int.MaxValue)
                {
                    break;
                }
                // node is now visitises
                used[minNode] = true;

                for (int i = 0; i < n; i++)
                {

                    if (graph[minNode, i] > 0)
                    {
                        var shortestToMinNode = distance[minNode];
                        var distanceToNextNode = graph[minNode, i];

                        var totalDistance = shortestToMinNode + distanceToNextNode;
                        // if the total distance < currnt node distance
                        if (totalDistance < distance[i])
                        {
                            distance[i] = totalDistance;
                            previous[i] = minNode;
                        }
                    }
                }
            }

            if (distance[destinationNode] == int.MaxValue)
            {
                return null;
            }

            var path = new LinkedList<int>();
            int? currentNode = destinationNode;
            while (currentNode != null)
            {
                path.AddFirst(currentNode.Value);
                currentNode = previous[currentNode.Value];
            }

            return path.ToList();
        }

        public  void Start()
        {
            var graph = new[,]
            {
            // 0   1   2   3   4   5   6   7   8   9  10  11
            { 0,  0,  0,  0,  0,  0, 10,  0, 12,  0,  0,  0 }, // 0
            { 0,  0,  0,  0, 20,  0,  0, 26,  0,  5,  0,  6 }, // 1
            { 0,  0,  0,  0,  0,  0,  0, 15, 14,  0,  0,  9 }, // 2
            { 0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  7,  0 }, // 3
            { 0, 20,  0,  0,  0,  5, 17,  0,  0,  0,  0, 11 }, // 4
            { 0,  0,  0,  0,  5,  0,  6,  0,  3,  0,  0, 33 }, // 5
            {10,  0,  0,  0, 17,  6,  0,  0,  0,  0,  0,  0 }, // 6
            { 0, 26, 15,  0,  0,  0,  0,  0,  0,  3,  0, 20 }, // 7
            {12,  0, 14,  0,  0,  3,  0,  0,  0,  0,  0,  0 }, // 8
            { 0,  5,  0,  0,  0,  0,  0,  3,  0,  0,  0,  0 }, // 9
            { 0,  0,  0,  7,  0,  0,  0,  0,  0,  0,  0,  0 }, // 10
            { 0,  6,  9,  0, 11, 33,  0, 20,  0,  0,  0,  0 }, // 11
        };

            PrintPath(graph, 0, 9);
            PrintPath(graph, 0, 2);
            PrintPath(graph, 0, 10);
            PrintPath(graph, 0, 11);
            PrintPath(graph, 0, 1);
        }

        public  void PrintPath(int[,] graph, int sourceNode, int destinationNode)
        {
            Console.Write(
                "Shortest path [{0} -> {1}]: ",
                sourceNode,
                destinationNode);

            var path = DijkstraAlgorithm(graph, sourceNode, destinationNode);

            if (path == null)
            {
                Console.WriteLine("no path");
            }
            else
            {
                int pathLength = 0;
                for (int i = 0; i < path.Count - 1; i++)
                {
                    pathLength += graph[path[i], path[i + 1]];
                }

                var formattedPath = string.Join("->", path);
                Console.WriteLine("{0} (length {1})", formattedPath, pathLength);
            }
        }
    }
    public class BellmanFordAlgo
    {
        public struct Edge
        {
            public int Source;
            public int Destination;
            public int Weight;
        }

        public struct Graph
        {
            public int VerticesCount;
            public int EdgesCount;
            public Edge[] edge;
        }

        public static Graph CreateGraph(int verticesCount, int edgesCount)
        {
            Graph graph = new Graph();
            graph.VerticesCount = verticesCount;
            graph.EdgesCount = edgesCount;
            graph.edge = new Edge[graph.EdgesCount];

            return graph;
        }

        private static void Print(int[] distance, int count)
        {
            Console.WriteLine("Vertex   Distance from source");

            for (int i = 0; i < count; ++i)
                Console.WriteLine("{0}\t {1}", i, distance[i]);
        }
        public void Start()
        {
            int verticesCount = 5;
            int edgesCount = 8;
            Graph graph = CreateGraph(verticesCount, edgesCount);

            // Edge 0-1
            graph.edge[0].Source = 0;
            graph.edge[0].Destination = 1;
            graph.edge[0].Weight = -1;

            // Edge 0-2
            graph.edge[1].Source = 0;
            graph.edge[1].Destination = 2;
            graph.edge[1].Weight = 4;

            // Edge 1-2
            graph.edge[2].Source = 1;
            graph.edge[2].Destination = 2;
            graph.edge[2].Weight = 3;

            // Edge 1-3
            graph.edge[3].Source = 1;
            graph.edge[3].Destination = 3;
            graph.edge[3].Weight = 2;

            // Edge 1-4
            graph.edge[4].Source = 1;
            graph.edge[4].Destination = 4;
            graph.edge[4].Weight = 2;

            // Edge 3-2
            graph.edge[5].Source = 3;
            graph.edge[5].Destination = 2;
            graph.edge[5].Weight = 5;

            // Edge 3-1
            graph.edge[6].Source = 3;
            graph.edge[6].Destination = 1;
            graph.edge[6].Weight = 1;

            // Edge 4-3
            graph.edge[7].Source = 4;
            graph.edge[7].Destination = 3;
            graph.edge[7].Weight = -3;

            BellmanFord(graph, 0);
        }
        public static void BellmanFord(Graph graph, int source)
        {
            // vertices
            int verticesCount = graph.VerticesCount;
            // edges 
            int edgesCount = graph.EdgesCount;
            // array for the distance
            int[] distance = new int[verticesCount];
            // everything set to infinity
            for (int i = 0; i < verticesCount; i++)
                distance[i] = int.MaxValue;
            // start from 0
            distance[source] = 0;
            // loop trhough every vertx
            for (int i = 1; i <= verticesCount - 1; ++i)
            {
                // go throgh the edges
                for (int j = 0; j < edgesCount; ++j)
                {
                    int u = graph.edge[j].Source;
                    int v = graph.edge[j].Destination;
                    int weight = graph.edge[j].Weight;

                    // if the distance distance is less
                    if (distance[u] != int.MaxValue && distance[u] + weight < distance[v])
                        // swap it
                        distance[v] = distance[u] + weight;
                }
            }

            for (int i = 0; i < edgesCount; ++i)
            {
                int u = graph.edge[i].Source;
                int v = graph.edge[i].Destination;
                int weight = graph.edge[i].Weight;

                if (distance[u] != int.MaxValue && distance[u] + weight < distance[v])
                    Console.WriteLine("Graph contains negative weight cycle.");
            }

            Print(distance, verticesCount);
        }
    }
    }