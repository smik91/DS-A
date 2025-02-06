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
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("input.txt");
            int n = int.Parse(lines[0]);

            int[,] matrix = new int[n + 1, n + 1];

            for (int i = 1; i <= n; i++)
            {
                string[] symbols = lines[i].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                for (int j = 1; j <= n; j++)
                {
                    matrix[i, j] = int.Parse(symbols[j - 1]);
                }
            }

            int[] P = new int[n + 1];
            for (int i = 1; i <= n; i++)
            {
                bool flag = false;

                for (int j = 1; j <= n; j++)
                {
                    if (matrix[j, i] == 1)
                    {
                        P[i] = j;
                        flag = true;
                        break;
                    }
                }

            }

            string output = string.Join(" ", P.Skip(1));
            File.WriteAllText("output.txt", output);
        }
    }
}
