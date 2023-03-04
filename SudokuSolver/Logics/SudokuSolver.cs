namespace SudokuSolver.Logics
{
    public static class SudokuSolver
    {
        public static List<List<int>> SolvePuzzle(List<List<int>> unsolvedPuzzle)
        {
            List<List<int>> solvedPuzzle = new List<List<int>>();

            //Printing unsolved puzzle
            PrintPuzzleToConsole(unsolvedPuzzle);
            HashSet<List<int>> givenNumberPositions = SetHintNumbersHashSet(unsolvedPuzzle);

            //For the sudoku puzzles, 0's denote empty spaces

            for (int i=0; i<unsolvedPuzzle.Count; i++)
            {
                for(int j=0; j< unsolvedPuzzle[i].Count; j++)
                {

                }
            }
            return solvedPuzzle;
        }

        private static void PrintPuzzleToConsole(List<List<int>> puzzle)
        {
            //Displaying the passed in sudoku puzzle in the console.
            for (int i = 0; i < puzzle.Count; i++)
            {
                Console.WriteLine();
                if (i == 3 || i == 6)
                {
                    Console.WriteLine("---------------------");
                }
                for (int j = 0; j < puzzle[i].Count; j++)
                {
                    if (puzzle[i][j] != 0)
                    {
                        Console.Write(puzzle[i][j] + " ");
                    }
                    else
                    {
                        Console.Write("  ");
                    }

                    if (j == 2 || j == 5)
                    {
                        Console.Write("| ");
                    }
                }
            }
        }

        /// <summary>
        /// Used to create a HashSet of positions of the given numbers in an unsolved puzzle so that they aren't overwritten by accident.
        /// </summary>
        /// <param name="puzzle"></param>
        /// <returns>Returns a HashSet of value and position</returns>
        private static HashSet<List<int>> SetHintNumbersHashSet(List<List<int>> puzzle)
        {
            HashSet<List<int>> hintHashSet = new HashSet<List<int>>();

            for(int i=0; i<puzzle.Count; i++)
            {
                for (int j = 0; j < puzzle[i].Count; j++)
                {
                    if (puzzle[i][j] != 0)
                    {
                        hintHashSet.Add(new List<int> { i, j });
                    }                   
                }
            }

            return hintHashSet;
        }

        private static bool CheckIfValid(List<List<int>> puzzle, int row, int col)
        {
            int value = puzzle[row][col];
            bool valid = true;

            //Checking if value already exists on row.
            for(int i=0; i < puzzle[row].Count; i++)
            {
                //if we find the value where it is not the value itself, the solution is not valid.
                if (i != col && puzzle[row][i] == value)
                {
                    valid = false;
                    break;
                }
            }

            //Checking if value already exists on column
            //If we have already failed during the first check, we can just skip this one
            if(valid)
            {
                for(int i=0; i<puzzle.Count; i++)
                {
                    if(i != row && puzzle[i][col] == value)
                    {
                        valid = false;
                        break;
                    }
                }
            }

            //Checking if value already exists in the same square
            if (valid)
            {
                int sqrt = (int)Math.Sqrt(puzzle.Count);

                int rowOffset = sqrt * ((int) (row / sqrt));
                int colOffset = sqrt * ((int) (col / sqrt));


                for (int i=0; i<sqrt; i++)
                {
                    if (valid)
                    {
                        for (int j = 0; j < sqrt; j++)
                        {
                            if ((i + rowOffset != row && j + colOffset != col) && puzzle[i + rowOffset][j + colOffset] == value)
                            {
                                valid = false;
                                break;
                            }
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }

            return valid;
        }
    }
}
