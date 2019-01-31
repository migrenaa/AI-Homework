
namespace AI_Homework
{
    public static class BlindAlogorithms
    {
        public static char[][] Matrix { get; set; }

        public static void IterativeDeepeningDFS(Point start, Point end)
        {
            int depth = 0;
            while (true)
            {
                var result = depthLimitedSearch(start, end, depth);
                if (result != null)
                    return;

                Common.CleanMatrix(Matrix);
                depth++;
            }
        }

        private static Point depthLimitedSearch(Point current, Point goal, int depth)
        {
            Matrix[current.X][current.Y] = '*';
            if (depth == 0 && current.X == goal.X && current.Y == goal.Y)
                return current;

            if (depth > 0)
            {
                var children = Common.GetNeithbours(Matrix, current);
                foreach (var child in children)
                {
                    Matrix[child.X][child.Y] = '*';
                    var found = depthLimitedSearch(child, goal, depth - 1);
                    if (found != null)
                        return found;
                }
            }
            return null;
        }
    }
}
