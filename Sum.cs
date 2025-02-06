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
        class MainArray
        {
            private int subMasSize;
            private long[] subMasSum;
            private long[] mas;
            private int n;
            

            public MainArray(int size, long[] array)
            {
                n = size;
                subMasSize = (int)Math.Sqrt(n) + 1;
                mas = new long[n];
                Array.Copy(array, mas, n);
                int numBlocks = (n + subMasSize - 1) / subMasSize;
                subMasSum = new long[numBlocks];
                for (int i = 0; i < n; i++)
                {
                    subMasSum[i / subMasSize] += mas[i];
                }
            }

            public long Sum(int l, int r)
            {
                long sum = 0;
                int firstPart = l / subMasSize;
                int secondPart = (r - 1) / subMasSize;

                if (firstPart == secondPart)
                {
                    for (int i = l; i < r; i++)
                    {
                        sum += mas[i];
                    }
                }
                else
                {
                    int endOfFirstBlock = (firstPart + 1) * subMasSize;
                    for (int i = l; i < Math.Min(endOfFirstBlock, n); i++)
                    {
                        sum += mas[i];
                    }

                    for (int i = firstPart + 1; i < secondPart; i++)
                    {
                        sum += subMasSum[i];
                    }

                    int startOfEndBlock = secondPart * subMasSize;
                    for (int i = startOfEndBlock; i < r; i++)
                    {
                        sum += mas[i];
                    }
                }

                return sum;
            }

            public void Add(int index, long a)
            {
                int block = index / subMasSize;
                subMasSum[block] += a;
                mas[index] += a;
            }
        }

        static void Main()
        {
            using (StreamReader reader = new StreamReader(Console.OpenStandardInput()))
            using (StreamWriter writer = new StreamWriter(Console.OpenStandardOutput()))
            {
                int n = int.Parse(reader.ReadLine());

                long[] arr = new long[n];
                string[] elements = reader.ReadLine().Split(' ');
                for (int i = 0; i < n; i++)
                {
                    arr[i] = long.Parse(elements[i]);
                }

                MainArray blockArray = new MainArray(n, arr);

                int q = int.Parse(reader.ReadLine());

                StringBuilder result = new StringBuilder();

                for (int query = 0; query < q; query++)
                {
                    string line = reader.ReadLine();

                    string[] parts = line.Split(' ');
                    if (parts[0] == "FindSum")
                    {
                        int l = int.Parse(parts[1]);
                        int r = int.Parse(parts[2]);
                        long sum = blockArray.Sum(l, r);
                        result.AppendLine(sum.ToString());
                    }
                    else if (parts[0] == "Add")
                    {
                        int index = int.Parse(parts[1]);
                        long x = long.Parse(parts[2]);
                        blockArray.Add(index, x);
                    }
                }

                writer.Write(result.ToString());
            }
        }
    }
}
