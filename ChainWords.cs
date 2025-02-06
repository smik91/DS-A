using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Linq;

namespace AISD
{

    class Program
    {
        public static Dictionary<char, List<char>> graph = new Dictionary<char, List<char>>();
        public static Dictionary<char, int> vhodStepen = new Dictionary<char, int>();
        public static Dictionary<char, int> vihodStepen = new Dictionary<char, int>();

        static void Main()
        {
            var input = File.ReadAllLines("input.txt");
            int n = int.Parse(input[0]);
            var words = new List<string>();
            for (int i = 1; i <= n; i++)
            {
                words.Add(input[i]);
            }

            foreach (var word in words)
            {
                char start = word[0];
                char end = word[^1];

                if (!graph.ContainsKey(start)) graph[start] = new List<char>();
                if (!vhodStepen.ContainsKey(start)) vhodStepen[start] = 0;
                if (!vihodStepen.ContainsKey(start)) vihodStepen[start] = 0;
                if (!vhodStepen.ContainsKey(end)) vhodStepen[end] = 0;
                if (!vihodStepen.ContainsKey(end)) vihodStepen[end] = 0;

                graph[start].Add(end);
                vihodStepen[start]++;
                vhodStepen[end]++;
            }

            foreach (var key in vhodStepen.Keys)
            {
                if (vhodStepen[key] != vihodStepen[key])
                {
                    Console.WriteLine("No");
                    File.WriteAllText("output.txt", "No");
                    return;
                }
            }

            if (!IsSilnoSvyazan(words[0][0]))
            {
                Console.WriteLine("No");
                File.WriteAllText("output.txt", "No");
                return;
            }

            Console.WriteLine("Yes");
            File.WriteAllText("output.txt", "Yes");
        }

        static bool IsSilnoSvyazan(char start)
        {
            var visited = new HashSet<char>();
            DFS(start, visited);

            if (visited.Count != graph.Count)
            {
                return false;
            }

            return visited.Count == graph.Count;
        }

        static void DFS(char node, HashSet<char> visited)
        {
            visited.Add(node);
            if (!graph.ContainsKey(node))
            {
                return;
            }

            foreach (var imte in graph[node])
            {
                if (!visited.Contains(imte))
                {
                    DFS(imte, visited);
                }
            }
        }
    }
}