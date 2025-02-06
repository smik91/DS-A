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
            string input = File.ReadAllText("input.txt").Trim();
            int n = input.Length;

            int[,] dp = new int[n, n];

            for (int i = 0; i < n; i++)
            {
                dp[i, i] = 1;
            }

            for (int len = 2; len <= n; len++)
            {
                for (int i = 0; i <= n - len; i++)
                {
                    int j = i + len - 1;
                    if (input[i] == input[j])
                    {
                        dp[i, j] = dp[i + 1, j - 1] + 2;
                    }
                    else
                    {
                        dp[i, j] = Math.Max(dp[i + 1, j], dp[i, j - 1]);
                    }
                }
            }

            StringBuilder palindrome = new StringBuilder();
            int left = 0, right = n - 1;
            while (left <= right)
            {
                if (input[left] == input[right])
                {
                    palindrome.Append(input[left]);
                    left++;
                    right--;
                }
                else if (dp[left + 1, right] > dp[left, right - 1])
                {
                    left++;
                }
                else
                {
                    right--;
                }
            }

            string firstHalf = palindrome.ToString();
            string secondHalf = new string(firstHalf.Reverse().ToArray());
            if (left - 1 == right + 1)
            {
                secondHalf = secondHalf.Substring(1);
            }
            palindrome.Append(secondHalf);

            using (StreamWriter writer = new StreamWriter("output.txt"))
            {
                writer.WriteLine(dp[0, n - 1]);
                writer.WriteLine(palindrome.ToString());
            }
        }
    }
}