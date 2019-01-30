using System;
using System.Collections.Generic;
using System.Linq;

namespace AI_Homework
{
    public class Board
    {
        private Random random { get; set; }
        private int[] rows { get; set; }

        /**
         * Creates a new n x n board and randomly fills it with one
         * queen in each column.
         */
        public Board(int n)
        {
            random = new Random();
            rows = new int[n];
            this.Scramble();
        }

        /**
         * Returns the number of queens that conflict with (row,col), not
         * counting the queen in column col.
         */
        private int conflicts(int row, int col)
        {
            int count = 0;
            for (int c = 0; c < rows.Length; c++)
            {
                if (c == col) continue;
                int r = rows[c];
                if (r == row || Math.Abs(r - row) == Math.Abs(c - col)) count++;
            }
            return count;
        }

        /**
        * Randomly fills the board with one queen in each column.
        */
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

        /**
         * Fills the board with a legal arrangement of queens.
         */
        public void Solve()
        {
            int moves = 0;

            List<int> candidates = new List<int>();

            while (true)
            {

                // Find nastiest queen
                int maxConflicts = 0;
                candidates.Clear();
                for (int c = 0; c < rows.Length; c++)
                {
                    int conflictsCount = conflicts(rows[c], c);
                    if (conflictsCount == maxConflicts)
                    {
                        candidates.Add(c);
                    }
                    else if (conflictsCount > maxConflicts)
                    {
                        maxConflicts = conflictsCount;
                        candidates.Clear();
                        candidates.Add(c);
                    }
                }

                if (maxConflicts == 0)
                {
                    // Checked *every* queen and found no conflicts
                    return;
                }

                // Pick a random queen from those that had the most conflicts
                int worstQueenColumn =
                        candidates[(random.Next(candidates.Count))];

                // Move her to the place with the least conflicts.
                int minConflicts = rows.Length;
                candidates.Clear();
                for (int r = 0; r < rows.Length; r++)
                {
                    int conflictsCount = conflicts(r, worstQueenColumn);
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
                {
                    rows[worstQueenColumn] =
                        candidates[(random.Next(candidates.Count))];
                }

                moves++;
                if (moves == rows.Length * 2)
                {
                    // Trying too long... start over.
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
                    if (rows[col] == row)
                    {
                        // Queen
                        Console.Write("* ");
                    }
                    else
                    {
                        // Blank space
                        Console.Write("_ ");
                    }
                }
                Console.WriteLine();
            }
        }

    }
}
