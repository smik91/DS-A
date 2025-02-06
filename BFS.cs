using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AISD
{
    public class Program
    {
        public static Queue<int> queue = new Queue<int>();
        public static Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>();
        public static HashSet<int> visited = new HashSet<int>();
        public static int n;
        public static int[] marks;

        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("input.txt");
            n = int.Parse(lines[0].Split(' ', StringSplitOptions.RemoveEmptyEntries)[0]);
            marks = new int[n+1];

            for (int i = 1; i < lines.Length; i++)
            {
                int[] numbers = lines[i].Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                graph[i] = new List<int>();
                for (int j = 1; j <= numbers.Length; j++)
                {
                    if (numbers[j-1] == 1)
                    {
                        graph[i].Add(j);
                    }
                }
            }

            int counter = 1;

            for (int i = 1; i <= n; i++)
            {
                if (!visited.Contains(i))
                {
                    bsf(i, ref counter);
                }
            }

            StringBuilder sb = new StringBuilder();
            for (int i = 1; i < marks.Length; i++)
            {
                sb.Append(marks[i]);
                if(i != marks.Length - 1)
                {
                    sb.Append(" ");
                }
            }
            File.AppendAllText("output.txt", sb.ToString());
        }

        public static void bsf(int start, ref int counter)
        {
            queue.Enqueue(start);
            visited.Add(start);
            marks[start] = counter;
            counter++;

            while (queue.Count > 0)
            {
                int a = queue.Dequeue();
                for (int i = 0; i < graph[a].Count(); i++)
                {
                    if (!visited.Contains(graph[a][i]))
                    {
                        queue.Enqueue(graph[a][i]);
                        visited.Add(graph[a][i]);
                        marks[graph[a][i]] = counter;
                        counter++;
                    }
                }
            }
        }
    }
}
