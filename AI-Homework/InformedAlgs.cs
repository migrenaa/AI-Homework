
namespace AI_Homework
{
    using System;
    using System.Collections.Generic;
    using System.Linq;


    public static class InformedAlgs
    {
        public static char[][] Matrix { get; set; }
        public static int PathLength { get; set; }

        public static void AStar(APoint start, APoint target)
        {
            APoint current = null;
            var currentPaths = new List<APoint>();
            var visited = new List<APoint>();
            PathLength = 0;

            //G-score - distance from the starting location to the current
            int g = 0;

            // start by adding the original position to the open list
            currentPaths.Add(start);

            while (currentPaths.Count > 0)
            {
                // get the square with the lowest F score
                var lowest = currentPaths.Min(point => point.F);
                current = currentPaths.First(point => point.F == lowest);

                Matrix[current.X][current.Y] = '*';
                Console.WriteLine(current.Direction);
                PathLength++;

                // add the current square to the closed list
                visited.Add(current);

                // remove it from the open list
                currentPaths.Remove(current);

                // if we added the destination to the closed list, we've found a path
                if (visited.FirstOrDefault(point => point.X == target.X && point.Y == target.Y) != null)
                    break;

                var adjacentSquares = Common.GetNeithbours(Matrix, current);
                g++;

                foreach (var adjacentSquare in adjacentSquares)
                {
                    if (visited.FirstOrDefault(point =>
                               point.X == adjacentSquare.X
                            && point.Y == adjacentSquare.Y) != null)
                        continue;

                    if (currentPaths.FirstOrDefault(point =>
                               point.X == adjacentSquare.X
                            && point.Y == adjacentSquare.Y) == null)
                    {
                        adjacentSquare.G = g;
                        adjacentSquare.H = Common.CalculateManhattanDistance(adjacentSquare, target);
                        adjacentSquare.F = adjacentSquare.G + adjacentSquare.H;
                        adjacentSquare.Parent = current;

                        currentPaths.Insert(0, adjacentSquare);
                    }
                    else
                    {
                        if (g + adjacentSquare.H < adjacentSquare.F)
                        {
                            adjacentSquare.G = g;
                            adjacentSquare.F = adjacentSquare.G + adjacentSquare.H;
                            adjacentSquare.Parent = current;
                        }
                    }
                }
            }
        }
    }
}
