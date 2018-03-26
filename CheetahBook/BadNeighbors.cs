using System;
using System.Linq;

namespace CheetahBook
{
    // 2004 TCCC Online Round4
    public class BadNeighbors
    {
        public BadNeighbors()
        {
            var reader = new System.IO.StreamReader("Inputs_BadNeighbors.txt");
            Console.SetIn(reader);
        }

        public int MaxDonations(int[] donations)
        {
            var max = 0;
            var dp = new int[donations.Length];
            for (var i = 0; i < donations.Length - 1; i++)
            {
                dp[i] = donations[i];
                if (i > 0) dp[i] = Math.Max(dp[i], dp[i - 1]);
                if (i > 1) dp[i] = Math.Max(dp[i], dp[i - 2] + donations[i]);
                max = Math.Max(max, dp[i]);
            }
            Console.WriteLine($"First:{string.Join(" ", dp)}");

            for (var i = 0; i < donations.Length - 1; i++)
            {
                dp[i] = donations[i + 1];
                if (i > 0) dp[i] = Math.Max(dp[i], dp[i - 1]);
                if (i > 1) dp[i] = Math.Max(dp[i], dp[i - 2] + donations[i + 1]);
                max = Math.Max(max, dp[i]);
            }
            Console.WriteLine($"Second:{string.Join(" ", dp)}");

            return max;
        }

        public void Solve()
        {
            Console.WriteLine("BadNeighbors");
            var donations = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var maxD = MaxDonations(donations);
            Console.WriteLine($"{maxD}");
        }
    }
}
