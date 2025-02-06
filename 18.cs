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
        public static int k { get; private set; }
        private static long[] cache;

        static void Main(string[] args)
        {
            string[] strings = File.ReadAllLines("input.txt");
            string[] numbersAsString = strings[0].Split(' ');
            k = int.Parse(numbersAsString[0]);
            int n = int.Parse(numbersAsString[1]);

            cache = new long[n];
            for (int i = 0; i < n; i++)
            {
                cache[i] = -1;
            }

            long sum = CalculateFiles(n);
            File.WriteAllText("output.txt", sum.ToString());
        }

        public static long CalculateFiles(long currentSymbols)
        {
            if (currentSymbols <= 0)
            {
                return 0;
            }

            if (cache[currentSymbols - 1] != -1)
            {
                return cache[currentSymbols - 1];
            }

            long allCombinations = 0;
            long nextSymbols;

            for (int i = 1; i <= currentSymbols; i++)
            {
                long currentCombinations = (long) Math.Pow(k, i);
                allCombinations += currentCombinations;

                nextSymbols = currentSymbols - i - 1;
                allCombinations += currentCombinations * CalculateFiles(nextSymbols);
            }

            cache[currentSymbols - 1] = allCombinations;
            return allCombinations;
        }
    }
}
