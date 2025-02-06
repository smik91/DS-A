using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace AISD
{
    public class Program
    {
        static void Main(string[] args)
        {
            string stringN = Console.ReadLine();
            string stringKomari = Console.ReadLine();
            int n = int.Parse(stringN);
            string[] stringKomariArray = stringKomari.Split();
            int[] komari = new int[stringKomariArray.Length];
            for (int i = 0; i < komari.Length; i++)
            {
                komari[i] = int.Parse(stringKomariArray[i]);
            }

            if (n == 1)
            {
                Console.WriteLine(komari[0]);
                Console.WriteLine(1);
                return;
            }

            int[] dp = new int[n];
            int[] path = new int[n];

            for (int i = 0; i < n; i++)
            {
                dp[i] = -1;
                path[i] = -1;
            }

            dp[0] = komari[0];
            dp[1] = 0;

            path[0] = -1;
            path[1] = -1;

            for (int i = 0; i < n; i++)
            {
                if (dp[i] == -1)
                {
                    continue;
                }

                if (i + 2 < n && dp[i] + komari[i + 2] > dp[i + 2])
                {
                    dp[i + 2] = dp[i] + komari[i + 2];
                    path[i + 2] = i;
                }

                if (i + 3 < n && dp[i] + komari[i + 3] > dp[i + 3])
                {
                    dp[i + 3] = dp[i] + komari[i + 3];
                    path[i + 3] = i;
                }

            }

            if (dp[n - 1] == 0)
            {
                Console.WriteLine(-1);
                return;
            }

            Console.WriteLine(dp[n - 1]);
            List<int> resultPath = new List<int>();
            int current = n - 1;

            while (current != -1)
            {
                resultPath.Add(current + 1);
                current = path[current];
            }

            resultPath.Reverse();
            Console.WriteLine(string.Join(" ", resultPath));
        }
    }
}