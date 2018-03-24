using System;
using System.Linq;

namespace CheetahBook
{
    // SRM425
    class CrazyBot
    {
        bool[,] grid = new bool[100, 100];
        int[] dx = { 1, -1, 0, 0 };
        int[] dy = { 0, 0, 1, -1 };
        double[] probabilities = new double[4];

        public CrazyBot()
        {
            var reader = new System.IO.StreamReader("Inputs_CrazyBot.txt");
            Console.SetIn(reader);
        }

        public double GetProbability(int n, int east, int west, int south, int north)
        {
            probabilities[0] = east / 100d;
            probabilities[1] = west / 100d;
            probabilities[2] = south / 100d;
            probabilities[3] = north / 100d;

            return dfs(50, 50, n);
        }

        private double dfs(int x, int y, int n)
        {
            if (this.grid[x, y]) return 0d;
            if (n == 0) return 1;
            this.grid[x, y] = true;
            var ret = 0.0;
            for (var i = 0; i < 4; i++)
            {
                ret += dfs(x + dx[i], y + dy[i], n - 1) * probabilities[i];
            }
            this.grid[x, y] = false;
            Console.WriteLine($"P:{ret} n:{n}");
            return ret;
        }

        public void Solve()
        {
            Console.WriteLine("CrazyBot");
            var bot = new CrazyBot();
            var n = int.Parse(Console.ReadLine());
            var directions = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var prob = bot.GetProbability(n, directions[0], directions[1], directions[2], directions[3]);
            Console.WriteLine($"{prob}\n");
        }
    }
}
