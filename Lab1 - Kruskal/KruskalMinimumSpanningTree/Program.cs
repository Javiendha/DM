using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Kruskal
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] data = File.ReadAllLines("../../l1-1.txt");
            double[][] graph = new double[data.Length][];

            for (int i = 0; i < data.Length; i++)
            {
                graph[i] = data[i].Split(default(string[]), StringSplitOptions.RemoveEmptyEntries).Select(x => double.Parse(x)).ToArray<double>();
            }

            Console.WriteLine("\tInput data:");
            for (int i = 0; i < graph.Length; i++)
            {
                for (int j = 0; j < graph[i].Length; j++)
                {
                    Console.Write(graph[i][j] + "\t");
                }
                Console.WriteLine();
            }

            List<Edge> edges = new List<Edge>();
            for (int i = 0; i < graph.Length; i++)
            {
                for (int j = i; j < graph[i].Length; j++)
                {
                    if (graph[i][j] != 0)
                    {
                        edges.Add(new Edge() { StartN = i, EndN = j, Weight = graph[i][j] });
                    }
                }
            }
            
            List<int> vertices = new List<int>() { 0, 1, 2, 3, 4 };
            List<Edge> MinimumSpanningTree = Kruskals(edges, vertices);

            double totalWeight = 0;
            Console.WriteLine("\nConnected edges:");
            foreach (Edge edge in MinimumSpanningTree)
            {
                totalWeight += edge.Weight;
                Console.WriteLine("Vertex {0} to Vertex {1} weight is: {2}", edge.StartN, edge.EndN, edge.Weight);
            }
            Console.WriteLine("\nTotal Weight = {0}", totalWeight);
            Console.ReadLine();
        }

        static List<Edge> Kruskals(List<Edge> edges, List<int> vertices)
        {
            List<Edge> result = new List<Edge>();

            DisjointSet.Set set = new DisjointSet.Set(100);
            foreach (int vertex in vertices)
                set.MakeSet(vertex);

            var sortedEdge = edges.OrderBy(x => x.Weight).ToList();

            foreach (Edge edge in sortedEdge)
            {
                if (set.FindSet(edge.StartN) != set.FindSet(edge.EndN))
                {
                    result.Add(edge);
                    set.Union(edge.StartN, edge.EndN);
                }
            }
            return result;
        }
    }
}
