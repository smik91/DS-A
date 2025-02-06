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
        static long mod = 1000000007;

        static void Main(string[] args)
        {
            string string1 = Console.ReadLine();
            string[] stringNumbers = string1.Split();
            int n = int.Parse(stringNumbers[0]);
            int k = int.Parse(stringNumbers[1]);

            if (k < 0 || k > n)
            {
                Console.WriteLine(0);
                return;
            }

            long result = CalculateC(n, k);
            Console.WriteLine(result);
        }

        static long CalculateC(int n, int k)
        {
            long[] fact = new long[n + 1];
            long[] invFact = new long[n + 1];

            fact[0] = 1;
            for (int i = 1; i <= n; i++)
            {
                fact[i] = (fact[i - 1] * i) % mod;
            }

            invFact[n] = PowMod(fact[n], mod - 2);
            for (int i = n - 1; i >= 0; i--)
            {
                invFact[i] = (invFact[i + 1] * (i + 1)) % mod;
            }

            long res = fact[n];
            res = (res * invFact[k]) % mod;
            res = (res * invFact[n - k]) % mod;

            return res;
        }

        static long PowMod(long a, long n)
        {
            long result = 1;
            a %= mod;
            while (n > 0)
            {
                if ((n & 1) == 1)
                {
                    result = (result * a) % mod;
                }
                a = (a * a) % mod;
                n >>= 1;
            }
            return result;
        }
    }
}