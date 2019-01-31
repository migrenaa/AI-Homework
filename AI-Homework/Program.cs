using AI_Homework.Knn_Iris;
using System;

namespace AI_Homework
{
    class Program
    {
        static void Main(string[] args)
        {
            var start = new APoint { X = 0, Y = 0 };
            var target = new APoint { X = 5, Y = 4 };

            //var DFSmatrix = Common.GetRandomMatrix(7, 7);
            //var dfsMatrix = Algorithms.DFS(DFSmatrix, start, target);
            //Console.WriteLine("DFS path: ");
            //Common.PrettyPrint(dfsMatrix, 7, 7);

            //Console.WriteLine("---------------------------");

            //var BFSmatrix = Common.GetRandomMatrix(7, 7);
            //var bfsMatrix = Algorithms.BFS(BFSmatrix, start, target);
            //Console.WriteLine("BFS path: ");
            //Common.PrettyPrint(bfsMatrix, 7, 7);

            //var idsMatrix = Common.GetRandomMatrix(7, 7);
            //IDS.Matrix = idsMatrix;
            //IDS.Run(start, target);
            //Console.WriteLine("IDS path: ");
            //Common.PrettyPrint(idsMatrix, 7, 7);

            //var aStarMatrix = Common.GetRandomMatrix(7, 7);
            //InformedAlgs.Matrix = aStarMatrix;
            //InformedAlgs.AStar(start, target);
            //Console.WriteLine("A-Star path: ");
            //Console.WriteLine(InformedAlgs.PathLength);
            //Common.PrettyPrint(aStarMatrix, 7, 7);

            //int n = 1000;
            //QueensProblem queensProblem = new QueensProblem(n);
            //queensProblem.Solve();
            //queensProblem.GetSolution(n);

            //var knapsack = new Knapsack();
            //knapsack.InitializeItems();
            //Generator generator = new Generator(knapsack);
            //generator.Solve();
            //Console.Read();

            var knn = new Knn();
            knn.InitializeSets();
            int k = 12;
            knn.Classify(k);
            Console.WriteLine("Accuracy: " + knn.predictedAnswers * 100 / 20 + "%");

        }
    }
}
