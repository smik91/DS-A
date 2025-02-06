using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Linq;

namespace AISD
{
    public class Program
    {

        static List<long> result;
        static void Main(string[] args)
        {
            string[] inputText = File.ReadAllLines("input.txt");
            int n = int.Parse(inputText[0]);
            var numbers = inputText[1].Split(new char[] { ' ' })
                                      .Select(long.Parse)
                                      .OrderBy(x => x)
                                      .ToList();

            var countMap = new Dictionary<long, int>();
            foreach (var num in numbers)
            {
                if (!countMap.ContainsKey(num))
                {
                    countMap[num] = 0;
                }

                countMap[num]++;
            }

            result = new List<long>();
            result.Add(numbers[0] / 2);

            while (result.Count < n)
            {
                int currentIndex = result.Count() - 1;
                var possible = GetPossible(currentIndex);
                foreach (var x in possible)
                {
                    if (countMap.ContainsKey(x))
                    {
                        countMap[x]--;
                        if (countMap[x] == 0)
                        {
                            countMap.Remove(x);
                        }
                    }
                }
                

                foreach (var kvp in countMap)
                {
                    if (kvp.Value > 0)
                    {
                        result.Add(kvp.Key - result[0]);
                        break;
                    }
                }
            }

            using (var output = new StreamWriter("output.txt"))
            {
                foreach (var num in result.OrderBy(x => x))
                {
                    Console.WriteLine(num);
                    output.WriteLine(num);
                }
            }
        }

        static List<long> GetPossible(int index)
        {
            List<long> possible = new List<long>();
            possible.Add(result[index] + result[index]);
            for (int i = 0; i < index; i++)
            {
                long number = result[index] + result[i];
                possible.Add(number);
                possible.Add(number);
            }
            return possible;
        }
    }
}