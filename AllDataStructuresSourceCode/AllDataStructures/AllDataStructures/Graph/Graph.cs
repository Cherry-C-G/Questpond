using System;
using System.Collections.Generic;
using System.Text;
using AllDataStructures.LinkList.Simple;
namespace AllDataStructures.GraphDS
{
    public class Vertex
    {
        public string Label { get; set; }
    }
    public class Edge
    {
        public Vertex V1 { get; set; }
        public Vertex V2 { get; set; }
    }
    public class Graph
    {
        private int V;   // No. of vertices 

        private List<int>[] adj=null; //Adjacency Lists 

       public  Graph(int v)
        {
            V = v;
            adj = new List<int>[V];

            for (int i = 0; i < v; ++i)
                adj[i] = new List<int>();
        }
        public void addEdge(int v, int w)
        {
            adj[v].Add(w);
        }
        // prints BFS traversal from a given source s 

        public void BFS(int s)
        {
            bool[] visited = new bool[V];

            //create queue for BFS
            Queue<int> queue = new Queue<int>();
            visited[s] = true;
            queue.Enqueue(s);

            //loop through all nodes in queue
            while (queue.Count != 0)
            {
                //Deque a vertex from queue and print it.
                s = queue.Dequeue();
                Console.WriteLine("next->" + s);

                //Get all adjacent vertices of s
                foreach (var next in adj[s])
                {
                    if (!visited[next])
                    {
                        visited[next] = true;
                        queue.Enqueue(next);
                    }
                }

            }
        }
        public void DFS(int s)
        {
            bool[] visited = new bool[V];

            //For DFS use stack
            Stack<int> stack = new Stack<int>();
            visited[s] = true;
            stack.Push(s);

            while (stack.Count != 0)
            {
                s = stack.Pop();
                Console.WriteLine("next->" + s);
                foreach (int i in adj[s])
                {
                    if (!visited[i])
                    {
                        visited[i] = true;
                        stack.Push(i);
                    }
                }
            }
        }
    }

}
