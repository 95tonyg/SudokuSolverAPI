namespace SudokuSolver.Logics
{
    public static class SudokuSolver
    {
        public static List<List<int>> SolvePuzzle(List<List<int>> unsolvedPuzzle)
        {
            List<List<int>> solvedPuzzle = new List<List<int>>();

            //Printing unsolved puzzle
            PrintPuzzleToConsole(unsolvedPuzzle);

            //For the sudoku puzzles, 0's denote empty spaces

            for(int i=0; i<unsolvedPuzzle.Count; i++)
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

    }
}
