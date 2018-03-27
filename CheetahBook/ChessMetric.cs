using System;
using System.Collections.Generic;
using System.Linq;

namespace CheetahBook
{
    // TopCoder Collegiate Challenge Round4
    public class ChessMetric
    {
        int[] dx = { 1, 1, 0, -1, -1, -1,  0,  1,  1,  2, 2, 1, -1, -2, -2, -1 };
        int[] dy = { 0, 1, 1,  1,  0, -1, -1, -1, -2, -1, 1, 2,  2,  1, -1, -2 };

        public ChessMetric()
        {
            var reader = new System.IO.StreamReader("Inputs_ChessMetric.txt");
            Console.SetIn(reader);
        }

        private long HowMany(int size, int[] start, int[] end, int numMoves)
        {
            long[,,] dp = new long[size, size, numMoves + 1];
            int sx = start[0], sy = start[1];
            int ex = end[0], ey = end[1];
            dp[sy, sx, 0] = 1;

            for (var i = 1; i <= numMoves; i++)
            {
                for (var x = 0; x < size; x++)
                {
                    for (var y = 0; y < size; y++)
                    {
                        for (var j = 0; j < dx.Length; j++)
                        {
                            var nx = x + dx[j];
                            var ny = y + dy[j];
                            if (nx >= 0 && nx < size && ny >= 0 && ny < size) 
                                dp[ny, nx, i] += dp[y, x, i - 1];
                        }
                    }
                }
            }

            for (var n = 0; n <= numMoves; n++)
            {
                for (var i = 0; i < size; i++)
                {
                    for (var j = 0; j < size; j++)
                    {
                        Console.Write($"{dp[i, j, n]} ");
                    }
                    Console.Write("\n");
                }
                Console.WriteLine();
            }
            return dp[end[1], end[0], numMoves];
        }

        public void Solve()
        {
            Console.WriteLine("ChessMetric");
            var size = int.Parse(Console.ReadLine());
            var start = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var end = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var numMoves = int.Parse(Console.ReadLine());
            var ans = HowMany(size, start, end, numMoves);
            Console.WriteLine($"{ans}");
        }
    }
}
