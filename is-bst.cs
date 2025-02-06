using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AISD
{
    class Program
    {
        class Node
        {
            public long Value;
            public long Min;
            public long Max;
        }

        static void Main(string[] args)
        {
            const string inputFile = "bst.in";
            const string outputFile = "bst.out";

            try
            {
                using (var reader = new StreamReader(inputFile))
                using (var writer = new StreamWriter(outputFile))
                {
                    int n = int.Parse(reader.ReadLine());
                    if (n == 0)
                    {
                        writer.WriteLine("YES");
                        return;
                    }

                    Node[] tree = new Node[n];

                    tree[0] = new Node
                    {
                        Value = long.Parse(reader.ReadLine()),
                        Min = long.MinValue,
                        Max = long.MaxValue
                    };

                    bool isBST = true;

                    for (int i = 1; i < n; i++)
                    {
                        var line = reader.ReadLine().Split();
                        long m = long.Parse(line[0]);
                        int p = int.Parse(line[1]) - 1;
                        char c = line[2][0];

                        tree[i] = new Node { Value = m };

                        if (c == 'L')
                        {
                            tree[i].Min = tree[p].Min;
                            tree[i].Max = tree[p].Value - 1;
                        }
                        else
                        {
                            tree[i].Min = tree[p].Value;
                            tree[i].Max = tree[p].Max;
                        }

                        if (tree[i].Value < tree[i].Min || tree[i].Value > tree[i].Max)
                        {
                            isBST = false;
                            break;
                        }
                    }

                    writer.WriteLine(isBST ? "YES" : "NO");
                }
            }
            catch (Exception)
            {
                using (var writer = new StreamWriter("bst.out"))
                {
                    writer.WriteLine("NO");
                }
            }
        }
    }
}
