using System;
using System.Collections.Generic;
using System.Linq;

namespace AI_Homework
{
    public class QueensProblem
    {
        private Random random { get; set; }
        private int[] rows { get; set; }

        public QueensProblem(int n)
        {
            this.random = new Random();
            this.rows = new int[n];
            this.scramble();
        }


        public void Solve()
        {
            int moves = 0;
            var maxConflictsQueensList = new List<int>();

            while (true)
            {
                int maxConflicts = 0;
                maxConflictsQueensList.Clear();

                for (int col = 0; col < rows.Length; col++)
                {
                    int conflictsCount = getConflictsWithQueen(rows[col], col);
                    if (conflictsCount == maxConflicts)
                    {
                        maxConflictsQueensList.Add(col);
                    }
                    else if (conflictsCount > maxConflicts)
                    {
                        maxConflicts = conflictsCount;
                        maxConflictsQueensList.Clear();
                        maxConflictsQueensList.Add(col);
                    }
                }

                if (maxConflicts == 0)
                    return;

                int worstQueenColumn = maxConflictsQueensList[(random.Next(maxConflictsQueensList.Count))];


                var minConflictsQueensList = new List<int>();
                int minConflicts = rows.Length;
                minConflictsQueensList.Clear();
                for (int r = 0; r < rows.Length; r++)
                {
                    int conflictsCount = getConflictsWithQueen(r, worstQueenColumn);
                    if (conflictsCount == minConflicts)
                    {
                        minConflictsQueensList.Add(r);
                    }
                    else if (conflictsCount < minConflicts)
                    {
                        minConflicts = conflictsCount;
                        minConflictsQueensList.Clear();
                        minConflictsQueensList.Add(r);
                    }
                }

                if (minConflictsQueensList.Any())
                    rows[worstQueenColumn] = minConflictsQueensList[(random.Next(minConflictsQueensList.Count))];

                moves++;
                if (moves == rows.Length * 2)
                {
                    // Restart
                    scramble();
                    moves = 0;
                }
            }
        }


        public void GetSolution(int rowsCount)
        {
            for (int row = 0; row < rowsCount; row++)
            {
                for (int col = 0; col < rowsCount; col++)
                {
                    // Queen
                    if (rows[col] == row)
                        Console.Write("* ");
                    else
                        Console.Write("_ ");
                }
                Console.WriteLine();
            }
        }

        private int getConflictsWithQueen(int row, int col)
        {
            int count = 0;
            for (int column = 0; column < rows.Length; column++)
            {
                if (column == col)
                    continue;
                if (rows[column] == row || Math.Abs(rows[column] - row) == Math.Abs(column - col))
                    count++;
            }
            return count;
        }


        private void scramble()
        {
            for (int i = 0, n = rows.Length; i < n; i++)
            {
                rows[i] = i;
            }
            for (int i = 0, n = rows.Length; i < n; i++)
            {
                int j = random.Next(n);
                int rowToSwap = rows[i];
                rows[i] = rows[j];
                rows[j] = rowToSwap;
            }
        }

    }
}
