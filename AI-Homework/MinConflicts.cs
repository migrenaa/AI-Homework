using System;
using System.Collections.Generic;
using System.Linq;

namespace AI_Homework
{
    public class Board
    {
        private Random random { get; set; }
        private int[] rows { get; set; }

        public Board(int n)
        {
            this.random = new Random();
            this.rows = new int[n];
            this.Scramble();
        }

        private int getConflictsWithQueen(int row, int col)
        {
            int count = 0;
            for (int c = 0; c < rows.Length; c++)
            {
                if (c == col)
                    continue;
                int r = rows[c];
                if (r == row || Math.Abs(r - row) == Math.Abs(c - col))
                    count++;
            }
            return count;
        }


        public void Scramble()
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

        public void Solve()
        {
            int moves = 0;
            var candidates = new List<int>();

            while (true)
            {
                int maxConflicts = 0;
                candidates.Clear();

                for (int col = 0; col < rows.Length; col++)
                {
                    int conflictsCount = getConflictsWithQueen(rows[col], col);
                    if (conflictsCount == maxConflicts)
                    {
                        candidates.Add(col);
                    }
                    else if (conflictsCount > maxConflicts)
                    {
                        maxConflicts = conflictsCount;
                        candidates.Clear();
                        candidates.Add(col);
                    }
                }

                if (maxConflicts == 0)
                    return;

                // Pick a random queen from those that had the most conflicts
                int worstQueenColumn =
                        candidates[(random.Next(candidates.Count))];

                // Move her to the place with the least conflicts.
                int minConflicts = rows.Length;
                candidates.Clear();
                for (int r = 0; r < rows.Length; r++)
                {
                    int conflictsCount = getConflictsWithQueen(r, worstQueenColumn);
                    if (conflictsCount == minConflicts)
                    {
                        candidates.Add(r);
                    }
                    else if (conflictsCount < minConflicts)
                    {
                        minConflicts = conflictsCount;
                        candidates.Clear();
                        candidates.Add(r);
                    }
                }

                if (candidates.Any())
                    rows[worstQueenColumn] = candidates[(random.Next(candidates.Count))];

                moves++;
                if (moves == rows.Length * 2)
                {
                    // Restart
                    Scramble();
                    moves = 0;
                }
            }
        }


        public void PrettyPrint(int boardSize)
        {
            for (int row = 0; row < boardSize; row++)
            {
                for (int col = 0; col < boardSize; col++)
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
    }
}
