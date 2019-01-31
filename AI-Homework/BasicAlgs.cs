
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
                    continue;

                visited.Add(currentVertex);
                matrix[currentVertex.X][currentVertex.Y] = '*';

                if (currentVertex.X == end.X && currentVertex.Y == end.Y)
                    return matrix;

                var neighbours = Common.GetNeithbours(matrix, currentVertex);
                foreach (var neighbour in neighbours)
                {
                    if (!visited.Contains(neighbour))
                        queue.Enqueue(neighbour);
                }
            }
            return matrix;

        }

        public static char[][] DFS(char[][] matrix, Point start, Point end)
        {
            var visited = new List<Point>();
            var stack = new Stack<Point>();

            stack.Push(start);

            while (stack.Count > 0)
            {
                var currentVertex = stack.Pop();

                if (visited.Contains(currentVertex))
                    continue;

                visited.Add(currentVertex);
                matrix[currentVertex.X][currentVertex.Y] = '*';

                if (currentVertex.X == end.X && currentVertex.Y == end.Y)
                    return matrix;

                var neighbours = Common.GetNeithbours(matrix, currentVertex);
                foreach (var neighbour in neighbours)
                {
                    if (!visited.Contains(neighbour))
                        stack.Push(neighbour);
                }
            }
            return matrix;

        }

    }

}
