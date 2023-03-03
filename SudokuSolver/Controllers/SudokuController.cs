using Microsoft.AspNetCore.Mvc;
using SudokuSolver.Logics;

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

            List<List<int>> solvedPuzzle = Logics.SudokuSolver.SolvePuzzle(request.UnsolvedSudoku);
            bool solvable = false;
            if (solvedPuzzle.Count > 0)
            {
                solvable = true;
            }

            var result = new Sudoku
            {
                Solvable = solvable,
                SudokuMatrix = solvedPuzzle,
            };

            return new JsonResult(result);
        }
    }
}