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
            string string1 = Console.ReadLine();
            string string2 = Console.ReadLine();
            string string3 = Console.ReadLine();
            string string4 = Console.ReadLine();

            int n = int.Parse(string1);

            int[] array = new int[n];

            if (n > 0)
            {
                string[] arrayString = string2.Split();
                for (int i = 0; i < n; i++)
                {
                    array[i] = int.Parse(arrayString[i]);
                }
            }
            
            int k = int.Parse(string3);

            int[] requests = new int[k];

            if (k > 0)
            {
                string[] requestsInput = string4.Split();
                for (int i = 0; i < k; i++)
                {
                    requests[i] = int.Parse(requestsInput[i]);
                }
            }

            for (int i = 0; i < k; i++)
            {
                int x = requests[i];

                int isExists = BinarySearch(ref array, x);
                int index1 = LowerBound(ref array, x);
                int index2 = UpperBound(ref array, x);
                Console.WriteLine($"{isExists} {index1} {index2}");
            }
        }

        public static int BinarySearch(ref int[] array, int x)
        {
            int left = 0;
            int right = array.Length;
            while (left < right)
            {
                int k = (right + left) / 2;
                if (array[k] == x)
                {
                    return 1;
                }
                else
                {
                    if (x < array[k])
                    {
                        right = k;
                    }
                    else
                    {
                        left = k + 1;
                    }
                }
            }

            return 0;
        }
        public static int LowerBound(ref int[] array, int x)
        {
            int left = 0;
            int right = array.Length;
            while (left < right)
            {
                int k = (right + left) / 2;
                if (x <= array[k])
                {
                    right = k;
                }
                else
                {
                    left = k + 1;
                }
            }

            return left;
        }
        public static int UpperBound(ref int[] array, int x)
        {
            int left = 0;
            int right = array.Length;
            while (left < right)
            {
                int k = (right + left) / 2;
                if (x < array[k])
                {
                    right = k;
                }
                else
                {
                    left = k + 1;
                }
            }

            return left;
        }
    }
}
