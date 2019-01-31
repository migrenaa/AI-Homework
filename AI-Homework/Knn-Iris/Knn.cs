
namespace AI_Homework.Knn_Iris
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class Knn
    {
        public List<Iris> trainingSet;
        public List<Iris> testSet;
        public Random rand = new Random();
        public int predictedAnswers = 0;

        public Knn()
        {
            trainingSet = new List<Iris>();
            testSet = new List<Iris>();
        }

        public void InitializeSets()
        {
            string line;
            string path = @"C:\Users\matrona\Desktop\AI-Homework\AI-Homework\Knn-Iris\iris.txt";
            var file = new StreamReader(path);
            while ((line = file.ReadLine()) != null)
            {
                bool isTest = rand.Next(50) % 5 == 0;
                string[] data = line.Split(",");

                var iris = new Iris()
                {
                    Prop1 = Convert.ToDouble(data[0]),
                    Prop2 = Convert.ToDouble(data[1]),
                    Prop3 = Convert.ToDouble(data[2]),
                    Prop4 = Convert.ToDouble(data[3]),
                    Type = data[4],
                    ActualType = data[4]
                };

                if (isTest && testSet.Count < 20)
                    testSet.Add(iris);
                else
                    trainingSet.Add(iris);

            }
        }

        public void Classify(int k)
        {
            foreach (var test in testSet)
            {
                foreach (var train in trainingSet)
                {
                    train.Distance = calculateEuclideanDistance(test, train);
                }

                // Sort the training set by the distance from the current test object
                trainingSet.Sort(
                    delegate (Iris t, Iris t1)
                {
                    return t.Distance.CompareTo(t1.Distance);
                });

                var closest = new List<Iris>();
                for (int i = 0; i < k; i++)
                    closest.Add(trainingSet[i]);

                string predictedType = predictType(closest);

                if (predictedType == test.ActualType)
                    predictedAnswers++;

                Console.WriteLine("Actual type: " + test.ActualType + " predicted type: " + predictedType);
            }
        }

        private string predictType(List<Iris> closest)
        {
            var distinctTypes = closest.Select(x => x.Type).Distinct();
            int maxCount = 0;
            string maxCountType = distinctTypes.First();
            foreach (var type in distinctTypes)
            {
                int countByType = closest.Count(x => x.Type == type);
                if (maxCount < countByType)
                {
                    maxCount = countByType;
                    maxCountType = type;
                }
            }
            return maxCountType;
        }

        private double calculateEuclideanDistance(Iris from, Iris to)
        {
            double distance = Math.Pow((from.Prop1 - to.Prop2), 2)
                    + Math.Pow(from.Prop2 - to.Prop2, 2)
                    + Math.Pow(from.Prop3 - to.Prop3, 2)
                    + Math.Pow(from.Prop4 - to.Prop4, 2);
            return Math.Sqrt(distance);
        }
    }
}
