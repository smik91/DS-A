using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AISD
{
    public struct Doroga
    {
        public Doroga(int a, int b)
        {
            Gorod1 = a;
            Gorod2 = b;
        }

        public int Gorod1 { get; set; }
        public int Gorod2 { get; set; }
    }

    public class Stroitelstvo_dorog
    {
        public static int[] Goroda { get; set; }
        public static int[] razmeriKomponents { get; set; }

        public class Program
        {
            static void Main()
            {
                string[] lines = File.ReadAllLines("input.txt");
                int lineNumber = 0;

                string[] firstLine = lines[lineNumber++].Split(' ');
                int n = int.Parse(firstLine[0]); // kolvo gorodov
                int m = int.Parse(firstLine[1]); // kolvo dorog
                int q = int.Parse(firstLine[2]); // zemletryaska

                Doroga[] razrushenieDorogi = new Doroga[m + 1];
                for (int i = 1; i <= m; i++)
                {
                    string[] line = lines[lineNumber++].Split(' ');
                    int gorod1 = int.Parse(line[0]);
                    int gorod2 = int.Parse(line[1]);
                    razrushenieDorogi[i] = new Doroga(gorod1,gorod2);
                }

                int[] zemletr = new int[q];
                bool[] isDestroyedArray = new bool[m + 1];
                for (int i = 0; i < q; i++)
                {
                    int numberDorogi = int.Parse(lines[lineNumber++]);
                    zemletr[i] = numberDorogi;
                    isDestroyedArray[numberDorogi] = true;
                }

                Goroda = new int[n + 1];
                razmeriKomponents = new int[n + 1];
                for (int i = 1; i <= n; i++)
                {
                    Goroda[i] = i;
                    razmeriKomponents[i] = 0;
                }

                int componentCount = n;

                for (int i = 1; i <= m; i++)
                {
                    if (!isDestroyedArray[i])
                    {
                        if (Union(razrushenieDorogi[i].Gorod1, razrushenieDorogi[i].Gorod2))
                        {
                            componentCount--;
                        }
                    }
                }

                char[] result = new char[q];

                for (int i = q - 1; i >= 0; i--)
                {
                    result[i] = componentCount == 1 ? '1' : '0';

                    int numberRazrushenoyDorogi = zemletr[i];
                    if (Union(razrushenieDorogi[numberRazrushenoyDorogi].Gorod1, razrushenieDorogi[numberRazrushenoyDorogi].Gorod2))
                    {
                        componentCount--;
                    }
                }

                StringBuilder output = new StringBuilder(q);
                for (int i = 0; i < q; i++)
                {
                    output.Append(result[i]);
                }

                File.WriteAllText("output.txt", output.ToString());
                Console.WriteLine(output.ToString());
            }

            static int Find(int x)
            {
                if (Goroda[x] != x)
                {
                    Goroda[x] = Find(Goroda[x]);
                }
                return Goroda[x];
            }

            static bool Union(int x, int y)
            {
                int leaderX = Find(x);
                int leaderY = Find(y);

                if (leaderX == leaderY)
                {
                    return false;
                }

                if (razmeriKomponents[leaderX] < razmeriKomponents[leaderY])
                {
                    Goroda[leaderX] = leaderY;
                }
                else if (razmeriKomponents[leaderX] > razmeriKomponents[leaderY])
                {
                    Goroda[leaderY] = leaderX;
                }
                else
                {
                    Goroda[leaderY] = leaderX;
                    razmeriKomponents[leaderX]++;
                }

                return true;
            }
        }
    }
}
