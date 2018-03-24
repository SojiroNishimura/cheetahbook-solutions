using System;
using System.Collections.Generic;
using System.Linq;

namespace CheetahBook
{
    // SRM453.5
    public class MazeMaker
    {
        public MazeMaker()
        {
            var reader = new System.IO.StreamReader("Inputs_MazeMaker.txt");
            Console.SetIn(reader);
        }

        public int LongestPath(string[] maze, int startRow, int startCol,
                               int[] moveRow, int[] moveCol)
        {
            // Initialize cost array which stores the cost to each position.
            int width = maze[0].Length, height = maze.Length;
            var costs = new int[height, width];
            for (var i = 0; i < height; i++)
                for (var j = 0; j < width; j++)
                    costs[i, j] = -1;
            // The cost of initial position is 0
            costs[startRow, startCol] = 0;

            var q = new Queue<Tuple<int, int>>();
            q.Enqueue(Tuple.Create(startCol, startRow));
            while (q.Any())
            {
                var pos = q.Dequeue();
                int x = pos.Item1, y = pos.Item2;
                for (var i = 0; i < moveRow.Length; i++)
                {
                    int nextX = x + moveCol[i], nextY = y + moveRow[i];

                    // If next position is within the maze and the position
                    // is passable but not visited, then update the cost of
                    // the position by adding 1 to previous position's cost
                    // and enqueue next reachable position.
                    if (nextX >= 0 && nextX < width
                        && nextY >= 0 && nextY < height
                        && costs[nextY, nextX] == -1
                        && maze[nextY][nextX] == '.')
                    {
                        costs[nextY, nextX] = costs[y, x] + 1;
                        q.Enqueue(Tuple.Create(nextX, nextY));
                    }
                }
            }

            var max = 0;
            for (var i = 0; i < height; i++)
            {
                for (var j = 0; j < width; j++)
                {
                    // If there is an unreachable position, then return 1,
                    // otherwise return the biggest one within the costs matrix.
                    if (maze[i][j] == '.' && costs[i, j] == -1) return -1;
                    else max = Math.Max(max, costs[i, j]);
                }
            }
            return max;
        }

        public void Solve()
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
