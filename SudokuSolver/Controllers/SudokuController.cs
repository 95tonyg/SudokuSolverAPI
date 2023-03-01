using Microsoft.AspNetCore.Mvc;

namespace SudokuSolver.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SudokuController : ControllerBase
    {

        private readonly ILogger<SudokuController> _logger;

        public SudokuController(ILogger<SudokuController> logger)
        {
            _logger = logger;
        }

        [HttpPost(Name = "SolveSudoku")]
        public IActionResult Post(SudokuRequest request)
        {
            Console.WriteLine("Request");
            //Displaying the passed in sudoku puzzle in the console.
            for(int i=0;i< request.UnsolvedSudoku.Count; i++)
            {
                Console.WriteLine();
                if(i == 3 || i == 6)
                {
                    Console.WriteLine("---------------------");
                }
                for (int j=0; j < request.UnsolvedSudoku[i].Count; j++)
                {
                    Console.Write(request.UnsolvedSudoku[i][j] + " ");
                    if(j == 2 || j == 5)
                    {
                        Console.Write("| ");
                    }
                }
            }

            var result = new Sudoku
            {
                Solvable = true,
                SudokuMatrix = new List<List<int>> { new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, new List<int>{ 1 } }
            };

            return new JsonResult(result);
        }
    }
}