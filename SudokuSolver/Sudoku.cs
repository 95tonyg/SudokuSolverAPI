namespace SudokuSolver
{
    public class Sudoku
    {
        public bool Solvable { get; set; }

        public List<List<int>>? SudokuMatrix { get; set; }
    }

    public class SudokuRequest
    {
        public List<List<int>> UnsolvedSudoku { get; set; }
    }
}