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
            using (StreamReader reader = new StreamReader("input.txt"))
            using (StreamWriter writer = new StreamWriter("output.txt"))
            {
                int n = int.Parse(reader.ReadLine());
                int[] a = reader.ReadLine().Split().Select(int.Parse).ToArray();

                int length = LIS(a);
                writer.WriteLine(length);
                Console.WriteLine(length);
            }

        }

        static int LIS(int[] a)
        {
            int n = a.Length;
            int[] f = new int[n];
            int size = 0;

            for (int i = 0; i < a.Length; i++)
            {
                int pos = UpperBound(f, size, a[i]);
                f[pos] = a[i];
                if (pos == size)
                {
                    size++;
                }
            }

            return size;
        }

        static int UpperBound(int[] mas, int size, int x)
        {
            int l = 0, r = size;
            while (l < r)
            {
                int k = l + (r - l) / 2;
                if (mas[k] < x)
                {
                    l = k + 1;
                }
                else
                {
                    r = k;
                }
            }

            return l;
        }
    }
}