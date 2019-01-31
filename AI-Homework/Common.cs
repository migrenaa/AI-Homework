using System;
using System.Collections.Generic;
using System.Text;

namespace AI_Homework
{
    public static class Common
    {
        public static void CleanMatrix(char[][] matrix)
        {
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    if (matrix[i][j] == '*')
                    {
                        matrix[i][j] = '1';
                    }
                }
            }
        }

        public static int CalculateManhattanDistance(APoint from, APoint to)
        {
            return Math.Abs(to.X - from.X) + Math.Abs(to.Y - from.Y);
        }

        public static List<APoint> GetNeithbours(char[][] matrix, Point vertex)
        {
            var neighbours = new List<APoint>();

            if (vertex.X < matrix.Length - 1 && matrix[vertex.X + 1][vertex.Y] == '1')
            {
                neighbours.Add(new APoint { X = vertex.X + 1, Y = vertex.Y, Direction = "down" });
            }

            if (vertex.Y < matrix[0].Length - 1 && matrix[vertex.X][vertex.Y + 1] == '1')
            {
                neighbours.Add(new APoint { X = vertex.X, Y = vertex.Y + 1 , Direction = "right"});
            }

            if (vertex.X > 0 && matrix[vertex.X - 1][vertex.Y] == '1')
            {
                neighbours.Add(new APoint { X = vertex.X - 1, Y = vertex.Y, Direction = "up"});
            }

            if (vertex.Y > 0 && matrix[vertex.X][vertex.Y - 1] == '1')
            {
                neighbours.Add(new APoint { X = vertex.X, Y = vertex.Y - 1, Direction = "left" });
            }
            return neighbours;
        }

        

        public static char[][] GetRandomMatrix(int n, int m)
        {
            //char[][] matrix = new char[7][]
            //{
            //    new char[7] {'1', '1', '0','1','1', '1', '1' },
            //    new char[7] {'1', '0', '0','1','1', '1', '1' },
            //    new char[7] {'1', '1', '1','1','1', '1', '1' },
            //    new char[7] {'1', '1', '1','0','1', '1', '1' },
            //    new char[7] {'1', '1', '1','0','1', '1', '1' },
            //    new char[7] {'1', '1', '0','0','1', '1', '1' },
            //    new char[7] {'1', '1', '1','1','1', '1', '1' },
            //};

            char[][] matrix = new char[7][]
            {
                new char[7] {'1', '0','0','1','1','1','1'},
                new char[7] {'1', '0','0','1','1','1','1'},
                new char[7] {'1', '1','1','1','1', '1','1'},
                new char[7] {'1', '1','1','0','1', '1', '1'},
                new char[7] {'1', '1','1','0','1', '1', '1'},
                new char[7] {'1', '1','0','0','1', '1', '1'},
                new char[7] {'1', '1','1','1','1', '1','1'},

            };

            return matrix;
        }

        public static void PrettyPrint(char[][] matrix, int m, int n)
        {
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(matrix[i][j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }


    }

    public class Point
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Point parent { get; set; }
    }

    public class APoint : Point
    {
        public int G { get; set; }
        public int H { get; set; }
        public int F { get; set; }
        public string Direction { get; set; }
        public APoint Parent { get; set; }
    }
}
