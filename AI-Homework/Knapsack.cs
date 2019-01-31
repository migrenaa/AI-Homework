using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AI_Homework
{

    public class Item
    {
        public string Name { get; set; }
        public int Weight { get; set; }
        public int Value { get; set; }
    }

    public class Knapsack
    {
        public int capacity = 5000;
        public List<Item> items;

        public Knapsack()
        {
            this.items = new List<Item>();
        }

        public void InitializeItems()
        {
            items.Add(new Item { Name = "map", Weight = 90, Value = 150 });
            items.Add(new Item { Name = "compass", Weight = 130, Value = 35 });
            items.Add(new Item { Name = "water", Weight = 1530, Value = 200 });
            items.Add(new Item { Name = "sandwich", Weight = 500, Value = 160 });
            items.Add(new Item { Name = "glucose", Weight = 150, Value = 60 });
            items.Add(new Item { Name = "tin", Weight = 680, Value = 45 });
            items.Add(new Item { Name = "banana", Weight = 270, Value = 60 });
            items.Add(new Item { Name = "apple", Weight = 390, Value = 40 });
            items.Add(new Item { Name = "cheese", Weight = 230, Value = 30 });
            items.Add(new Item { Name = "beer", Weight = 520, Value = 10 });
            items.Add(new Item { Name = "suntan cream", Weight = 110, Value = 70 });
            items.Add(new Item { Name = "camera", Weight = 320, Value = 30 });
            items.Add(new Item { Name = "T-shirt", Weight = 240, Value = 15 });
            items.Add(new Item { Name = "trousers", Weight = 480, Value = 10 });
            items.Add(new Item { Name = "umbrella", Weight = 730, Value = 40 });
            items.Add(new Item { Name = "waterproof trousers", Weight = 420, Value = 70 });
            items.Add(new Item { Name = "waterproof overclothes", Weight = 430, Value = 75 });
            items.Add(new Item { Name = "note-case", Weight = 220, Value = 80 });
            items.Add(new Item { Name = "sunglasses", Weight = 70, Value = 20 });
            items.Add(new Item { Name = "towel", Weight = 180, Value = 12 });
            items.Add(new Item { Name = "socks", Weight = 40, Value = 50 });
            items.Add(new Item { Name = "book", Weight = 300, Value = 10 });
            items.Add(new Item { Name = "notebook", Weight = 900, Value = 1 });
            items.Add(new Item { Name = "tent", Weight = 2000, Value = 150 });
        }
    }

    public class Generator
    {

        private const double MUTATION_PROBAB = 0.2;

        private const int MAX_GENERATIONS = 100000;
        private const int POPULATION_SIZE = 1000;

        public List<string> population;
        public Knapsack knapsack;
        public Random random;

        public Generator(Knapsack knapsack)
        {
            this.knapsack = knapsack;
            this.population = new List<string>();
            this.random = new Random();
        }

        public void Solve()
        {
            int generations = 0;
            generatePopulation();
            sortByFintessFunction();

            while (true)
            {
                sortByFintessFunction();

                // show progress
                if (generations % 50 == 0)
                {
                    Console.WriteLine("After " + generations + " generations: " + bestSolution());

                }

                selection();
                sortByFintessFunction();
                crossover();

                generations++;
            }
        }

        // Variation - generate the initial population
        private void generatePopulation()
        {
            for (int i = 0; i < POPULATION_SIZE; i++)
            {
                string chromosome = generateChromosome();
                population.Add(chromosome);
            }
        }

        private string generateChromosome()
        {
            int knapsackSize = knapsack.items.Count;
            StringBuilder sb = new StringBuilder(knapsackSize);

            for (int i = 0; i < knapsackSize; i++)
            {
                char toAppend = random.NextDouble() <= 0.8 ? '0' : '1';
                sb.Append(toAppend);
            }
            return sb.ToString();
        }

        private void sortByFintessFunction()
        {
            population.Sort(
                delegate (string pop1, string pop2)
                {
                    return (calculateFitness(pop1)).CompareTo(calculateFitness(pop2));
                });
        }

        // Selection
        private int calculateFitness(string chromosome)
        {
            int totalWеight = 0;
            int totalValue = 0;
            int fitnesValue = 0;

            for (int i = 0; i < knapsack.items.Count; i++)
            {
                char gen = chromosome[i];
                if (gen == '0')
                    continue;

                totalWеight += this.knapsack.items[i].Weight;
                totalValue += this.knapsack.items[i].Value;
            }

            if (totalWеight <= knapsack.capacity)
                fitnesValue = totalValue;

            return fitnesValue;
        }

        private int bestFitness()
        {
            string bestChromosome = population[population.Count - 1];
            var fitness = calculateFitness(bestChromosome);
            return fitness;
        }

        private int bestSolution()
        {
            int bestValue = 0;
            string bestChrom = population[population.Count - 1];
            int bestWeight = 0;

            for (int i = 0; i < knapsack.items.Count; i++)
            {
                char gen = bestChrom[i];
                if (gen == '1')
                {
                    bestValue += knapsack.items[i].Value;
                    bestWeight += knapsack.items[i].Weight;
                }
            }
            Console.WriteLine("Best Value: " + bestValue);
            Console.WriteLine("Best Weight: " + bestWeight);
            return bestValue;
        }

        private void selection()
        {
            int removeCount = (int)(POPULATION_SIZE * 0.4);
            for (int i = 0; i < removeCount; i++)
                population.RemoveAt(i);
        }

        private void crossover()
        {
            int randIdx = random.Next(knapsack.items.Count - 1) + 1;
            while (population.Count < POPULATION_SIZE)
            {
                // Selection
                string parentOne = selectChromosome();
                string parentTwo = selectChromosome();

                // ensure that the parents aren't same
                while (parentTwo == parentOne)
                    parentTwo = selectChromosome();

                // create a child
                string child1 = parentOne.Substring(0, randIdx) + parentTwo.Substring(randIdx);

                // mutate the child
                child1 = mutate(child1);

                // add the child to the population
                population.Add(child1);

                // create the second child
                string child2 = parentTwo.Substring(0, randIdx) + parentOne.Substring(randIdx);

                // mutate the second child
                child2 = mutate(child2);

                // Add the second child to the population of the population size is not yet exceeded
                if (population.Count < POPULATION_SIZE)
                    population.Add(child2);
            }
        }

        private string selectChromosome()
        {
            return population[random.Next(population.Count / 4) * 4];
        }

        private string mutate(string chromosome)
        {
            string newChrom;
            double probab = random.NextDouble();

            if (probab <= MUTATION_PROBAB)
            {
                int randomIndex = random.Next(knapsack.items.Count);
                char gen = (char)chromosome.IndexOf(randomIndex.ToString());
                char newGen = gen == '0' ? '1' : '0';

                newChrom = chromosome.Substring(0, randomIndex) + newGen + chromosome.Substring(randomIndex + 1);
                return newChrom;
            }
            return chromosome;
        }
    }
}
