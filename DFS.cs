using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

class Program
{
    static int n;
    static List<int>[] input;
    static bool[] visited;
    static int[] result;
    static int labelCount = 1;

    static void Main()
    {
        string[] inputLines = File.ReadAllLines("input.txt");
        n = int.Parse(inputLines[0]);

        input = new List<int>[n + 1];
        for (int i = 1; i <= n; i++)
        {
            input[i] = new List<int>();
        }

        for (int i = 1; i <= n; i++)
        {
            string[] numbers = inputLines[i].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            for (int j = 1; j <= n; j++)
            {
                if (numbers[j - 1] == "1")
                {
                    input[i].Add(j);
                }
            }
        }

        visited = new bool[n + 1];
        result = new int[n + 1];

        for (int i = 1; i <= n; i++)
        {
            if (!visited[i])
            {
                DFS(i);
            }
        }

        List<string> output = new List<string>();
        for (int v = 1; v <= n; v++)
        {
            output.Add(result[v].ToString());
        }
        string resultString = string.Join(" ", output);

        File.WriteAllText("output.txt", resultString);
    }

    static void DFS(int v)
    {
        visited[v] = true;
        result[v] = labelCount++;

        foreach (var item in input[v])
        {
            if (!visited[item])
            {
                DFS(item);
            }
        }
    }
}
