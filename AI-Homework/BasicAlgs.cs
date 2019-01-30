﻿
using System.Collections.Generic;

namespace AI_Homework
{
  
    public static class Algorithms
    {
        public static char[][] BFS(char[][] matrix, Point start, Point end)
        {
            var visited = new List<Point>();
            var queue = new Queue<Point>();

            queue.Enqueue(start);

            while (queue.Count > 0)
            {
                var currentVertex = queue.Dequeue();

                if (visited.Contains(currentVertex))
                {
                    continue;
                }

                visited.Add(currentVertex);
                matrix[currentVertex.X][currentVertex.Y] = '*';

                if (currentVertex.X == end.X && currentVertex.Y == end.Y)
                {
                    System.Console.WriteLine("Search completed.");
                    return matrix;
                }

                var neighbours = Common.GetNeithbours(matrix, currentVertex);
                foreach (var neighbour in neighbours)
                {
                    if (!visited.Contains(neighbour))
                    {
                        queue.Enqueue(neighbour);
                    }
                }
            }
            return matrix;

        }

         }

}