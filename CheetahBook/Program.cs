using System;
using System.Linq;

namespace CheetahBook
{
    class Solution
    {
        public static void Main(string[] args)
        {
            SolveCrazyBot();
        }

        static void SolveCrazyBot()
        {
            var bot = new CrazyBot();
            var n = int.Parse(Console.ReadLine());
            var directions = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var prob = bot.GetProbability(n, directions[0], directions[1], directions[2], directions[3]);
            Console.WriteLine($"{prob}");            
        }
    }
}
