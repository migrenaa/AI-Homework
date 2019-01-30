using System;

namespace AI_Homework
{
    class Program
    {
        static void Main(string[] args)
        {
            var start = new APoint { X = 0, Y = 0 };
            var target = new APoint { X = 5, Y = 4 };

            //var BFSmatrix = Common.GetRandomMatrix(7, 7);
            //var newMatrix = Algorithms.BFS(BFSmatrix, start, target);
            //Console.WriteLine("BFS path: ");
            //Common.PrettyPrint(newMatrix, 7, 7);

            //var iterativeDeepeningDFSMatrix = Common.GetRandomMatrix(7, 7);
            //BlindAlogorithms.Matrix = iterativeDeepeningDFSMatrix;
            //BlindAlogorithms.IterativeDeepeningDFS(start, target);
            //Console.WriteLine("IDS path: ");
            //Common.PrettyPrint(iterativeDeepeningDFSMatrix, 7, 7);



            //var aStarMatrix = Common.GetRandomMatrix(7, 7);
            //InformedAlgs.Matrix = aStarMatrix;
            //InformedAlgs.AStar(start, target);
            //Console.WriteLine("A-Star path: ");
            //Common.PrettyPrint(aStarMatrix, 7, 7);

            //Board board = new Board(5000);
            //Console.WriteLine(DateTime.Now + ": Algorithm is running..");
            //board.Solve();
            //Console.WriteLine(DateTime.Now + ": Algorithm finished.");
            //board.PrettyPrint(10000);
            Console.Read();
        }
    }
}
