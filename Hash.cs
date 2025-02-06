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
        static void Main()
        {
            string[] inputText = File.ReadAllLines("input.txt");
            
            string[] firstLine = inputText[0].Split(' ', StringSplitOptions.RemoveEmptyEntries);
            int m = int.Parse(firstLine[0]);
            int c = int.Parse(firstLine[1]);
            int n = int.Parse(firstLine[2]);

            int[] keys = new int[n];
            for (int i = 0; i < n; i++)
            {
                keys[i] = int.Parse(inputText[i + 1]);
            }

            int[] hashTable = new int[m];
            for (int i = 0; i < m; i++)
            {
                hashTable[i] = -1;
            }

            for (int i = 0; i < keys.Length; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    int index = ((keys[i] % m) + c * j) % m;

                    if (hashTable[index] == keys[i])
                    {
                        break;
                    }
                    else if (hashTable[index] == -1)
                    {
                        hashTable[index] = keys[i];
                        break;
                    }
                }
            }

            string output = string.Join(" ", hashTable);
            File.WriteAllText("output.txt", output);

        }
    }
}
