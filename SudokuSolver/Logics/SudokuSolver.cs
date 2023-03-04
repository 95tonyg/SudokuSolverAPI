using System.Collections.Generic;

namespace SudokuSolver.Logics
{
    public static class SudokuSolver
    {
        public static List<List<int>> SolvePuzzle(List<List<int>> unsolvedPuzzle)
        {

            //Printing unsolved puzzle
            PrintPuzzleToConsole(unsolvedPuzzle, new List<int> { -1,-1});
            List<List<int>> givenNumberPositions = SetHintNumbersListSet(unsolvedPuzzle);

            Console.WriteLine(String.Join(",", givenNumberPositions));

            //For the sudoku puzzles, 0's denote empty spaces

            for (int i=0; i<unsolvedPuzzle.Count; i++)
            {
                for(int j=0; j< unsolvedPuzzle[i].Count; j++)
                {
                    //If the current position is a given number, we ignore
                    //Otherwise we try numbers.
                    if(!CheckIfListIsInListSet(givenNumberPositions, new List<int> {i,j})){
                        while (true)
                        {
                            if (unsolvedPuzzle[i][j] < unsolvedPuzzle.Count)
                            {
                                unsolvedPuzzle[i][j]++;
                                PrintPuzzleToConsole(unsolvedPuzzle, new List<int> { i, j});
                                if (CheckIfValid(unsolvedPuzzle, i, j))
                                {
                                    //If the value is valid, we go onto the next cell
                                    break;
                                }
                            }
                            //If the value is greater than 9, we need to back track.
                            else
                            {
                                unsolvedPuzzle[i][j] = 0;
                                if (j == 0)
                                {
                                    i--;
                                    j = unsolvedPuzzle.Count - 1;
                                }
                                else
                                {
                                    j--;
                                }

                                while (true)
                                {
                                    if (CheckIfListIsInListSet(givenNumberPositions, new List<int> { i, j }))
                                    {
                                        //If the spot is one that is given, we need to continue back tracking.
                                        if (j == 0)
                                        {
                                            i--;
                                            j = unsolvedPuzzle.Count - 1;
                                        }
                                        else
                                        {
                                            j--;
                                        }
                                    }
                                    else
                                    {
                                        break;
                                    }
                                    
                                }


                                if(j == 0)
                                {
                                    i--;
                                    j= unsolvedPuzzle.Count-1;
                                }
                                else
                                {
                                    j--;
                                }
                                break;
                            }
                        }
                        
                    }
                }
            }

            PrintPuzzleToConsole(unsolvedPuzzle, new List<int> { -1, -1 });

            return unsolvedPuzzle;
        }

        private static void PrintPuzzleToConsole(List<List<int>> puzzle, List<int> currentPosition)
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
                        if (currentPosition[0] == i && currentPosition[1] == j)
                        {
                            Console.BackgroundColor = ConsoleColor.Blue;
                            Console.Write(puzzle[i][j] + " ");
                            Console.BackgroundColor = ConsoleColor.Black;
                        }
                        else
                        {
                            Console.Write(puzzle[i][j] + " ");
                        }
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
            Console.WriteLine("");
            Console.WriteLine("************************************************");
        }

        /// <summary>
        /// Used to create a HashSet of positions of the given numbers in an unsolved puzzle so that they aren't overwritten by accident.
        /// </summary>
        /// <param name="puzzle"></param>
        /// <returns>Returns a HashSet of value and position</returns>
        private static List<List<int>> SetHintNumbersListSet(List<List<int>> puzzle)
        {
            List<List<int>> hintHashSet = new List<List<int>>();

            for(int i=0; i<puzzle.Count; i++)
            {
                for (int j = 0; j < puzzle[i].Count; j++)
                {
                    if (puzzle[i][j] != 0)
                    {
                        hintHashSet.Add(new List<int> { i, j });
                        Console.WriteLine("Adding " + i + " " + j + " to HashSet");
                    }                   
                }
            }

            return hintHashSet;
        }

        private static bool CheckIfListIsInListSet(List<List<int>> listSet, List<int> list) 
        {
            bool inSet = false;

            listSet.ForEach(x =>
            {
                if (x.SequenceEqual(list))
                {
                    inSet = true;
                    return;
                }
            });

            return inSet;
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
