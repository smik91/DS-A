using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.IO;

namespace AISD
{
    public class Program
    {
        static void Main()
        {
            using var input = new StreamReader("huffman.in");
            {
                using var output = new StreamWriter("huffman.out");
                {

                    int n = int.Parse(input.ReadLine());
                    long[] A = new long[n];

                    string[] items = input.ReadLine().Split(new char[] { ' ', '\t', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                    for (int i = 0; i < n; i++)
                    {
                        A[i] = long.Parse(items[i]);
                    }

                    int posA = 0;
                    int posB = 0;
                    int endA = n;
                    int endB = 0;
                    long[] B = new long[2 * n];
                    long totalSum = 0;

                    while ((endA - posA) + (endB - posB) > 1)
                    {
                        long min1, min2;

                        if (posA < endA && (posB >= endB || A[posA] <= B[posB]))
                        {
                            min1 = A[posA++];
                        }
                        else
                        {
                            min1 = B[posB++];
                        }

                        if (posA < endA && (posB >= endB || A[posA] <= B[posB]))
                        {
                            min2 = A[posA++];
                        }
                        else
                        {
                            min2 = B[posB++];
                        }

                        long sum = min1 + min2;
                        totalSum += sum;
                        B[endB++] = sum;
                    }

                    output.WriteLine(totalSum);
                    Console.WriteLine(totalSum);
                }
            }
        }
    }
}
