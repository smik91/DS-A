using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AISD
{
    public class Program
    {
        static void Main()
        {
            int s;
            int[] p;

            using (StreamReader sr = new StreamReader("input.txt"))
            {
                s = int.Parse(sr.ReadLine());
                int[] n = new int[s];
                int[] m = new int[s];

                for (int i = 0; i < s; i++)
                {
                    string[] parts = sr.ReadLine().Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                    n[i] = int.Parse(parts[0]);
                    m[i] = int.Parse(parts[1]);
                }

                p = new int[s + 1];
                p[0] = n[0];
                for (int i = 1; i <= s; i++)
                {
                    p[i] = m[i - 1];
                }
            }

            int[,] dp = new int[s, s];

            for (int i = 0; i < s; i++)
            {
                dp[i, i] = 0;
            }

            for (int L = 2; L <= s; L++)
            {
                for (int i = 0; i <= s - L; i++)
                {
                    int j = i + L - 1;
                    dp[i, j] = int.MaxValue;
                    for (int k = i; k < j; k++)
                    {
                        int cost = dp[i, k] + dp[k + 1, j] + p[i] * p[k + 1] * p[j + 1];
                        if (cost < dp[i, j])
                        {
                            dp[i, j] = cost;
                        }
                    }
                }
            }

            using (StreamWriter sw = new StreamWriter("output.txt"))
            {
                sw.WriteLine(dp[0, s - 1]);
            }
        }
    }
}