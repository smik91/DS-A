using System;
using System.IO;

class Program
{
    static void Main()
    {
        string inputFile = "input.txt";
        string outputFile = "output.txt";
        string[] lines = File.ReadAllLines(inputFile);

        int n = int.Parse(lines[0]);

        long[] heap = new long[n + 1];
        string[] elements = lines[1].Split(' ', StringSplitOptions.RemoveEmptyEntries);
        for (int i = 1; i <= n; i++)
        {
            heap[i] = long.Parse(elements[i - 1]);
        }

        bool isHeap = true;
        for (int i = 1; i <= n / 2; i++)
        {
            int left = 2 * i;
            int right = 2 * i + 1;

            if (left <= n && heap[i] > heap[left])
            {
                isHeap = false;
                break;
            }

            if (right <= n && heap[i] > heap[right])
            {
                isHeap = false;
                break;
            }
        }

        using (StreamWriter writer = new StreamWriter(outputFile))
        {
            writer.WriteLine(isHeap ? "Yes" : "No");
        }
    }
}