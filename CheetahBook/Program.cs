using System;
using System.Linq;

namespace CheetahBook
{
    class Solution
    {
        public static void Main(string[] args)
        {
            //SolveCrazyBot();
            //SolveMazeMaker();
            new NumberMagicEasy().Solve();
        }

        static void SolveCrazyBot()
        {
            Console.WriteLine("CrazyBot");
            var bot = new CrazyBot();
            var n = int.Parse(Console.ReadLine());
            var directions = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var prob = bot.GetProbability(n, directions[0], directions[1], directions[2], directions[3]);
            Console.WriteLine($"{prob}\n");            
        }

        static void SolveMazeMaker()
        {
            Console.WriteLine("MazeMaker");
            var mazeMaker = new MazeMaker();
            var n = int.Parse(Console.ReadLine());
            var maze = new string[n];
            for (var i = 0; i < n; i++) maze[i] = Console.ReadLine();
            var startPos = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var moveRow = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var moveCol = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var ans = mazeMaker.LongestPath(maze, startPos[0], startPos[1],
                                            moveRow, moveCol);
            Console.WriteLine($"{ans}\n");
        }
    }
}
