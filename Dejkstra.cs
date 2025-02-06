using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Linq;

namespace AISD
{
    public class Program
    {
        static void Main(string[] args)
        {
            var text = File.ReadAllLines("input.txt");
            var firstLine = text[0].Split();
            int n = int.Parse(firstLine[0]);
            int m = int.Parse(firstLine[1]);

            var graph = new List<(int number, int value)>[n + 1];
            for (int i = 1; i <= n; i++)
            {
                graph[i] = new List<(int number, int value)>();
            }

            for (int i = 1; i <= m; i++)
            {
                var rebro = text[i].Split();
                int u = int.Parse(rebro[0]);
                int v = int.Parse(rebro[1]);
                int w = int.Parse(rebro[2]);

                graph[u].Add((v, w));
                graph[v].Add((u, w));
            }

            var array = new long[n + 1];
            Array.Fill(array, long.MaxValue);
            array[1] = 0;

            var queue = new SortedSet<(long dist, int vertex)>();
            queue.Add((0, 1));

            while (queue.Count > 0)
            {
                var (number, value) = queue.Min;
                queue.Remove(queue.Min);

                if (number > array[value])
                {
                    continue;
                }

                foreach (var (sosed, valueSosed) in graph[value])
                {
                    long newValue = number + valueSosed;
                    if (newValue < array[sosed])
                    {
                        queue.Remove((array[sosed], sosed));
                        array[sosed] = newValue;
                        queue.Add((newValue, sosed));
                    }
                }
            }

            File.WriteAllText("output.txt", array[n].ToString());
        }
    }
}