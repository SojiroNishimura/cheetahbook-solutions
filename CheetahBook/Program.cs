using System;
using System.Linq;

namespace CheetahBook
{
    class Solution
    {
        public static void Main(string[] args)
        {
            var reader = new System.IO.StreamReader("Inputs.txt");
            Console.SetIn(reader);

            var n = int.Parse(Console.ReadLine());
            var directions = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var bot = new CrazyBot();
            var prob = bot.GetProbability(n, directions[0], directions[1], directions[2], directions[3]);
            Console.WriteLine($"{prob}");
        }
    }
}
