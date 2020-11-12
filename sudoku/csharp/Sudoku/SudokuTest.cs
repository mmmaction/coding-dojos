using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Sudoku
{
  [TestClass]
  public class SudokuTest
  {
    [TestMethod]
    public void SolveIt_When_SudokuSolvable_SingleMissingEntry_ThenIsSolved()
    {

      int?[][] sudoku = new int?[4][];

      // Set the values of the first array in the jagged array structure.
      sudoku[0] = new int?[] { 3, 1, null, 2 };
      sudoku[1] = new int?[] { 4, 2, 3, 1 };
      sudoku[2] = new int?[] { 2, 4, 1, 3 };
      sudoku[3] = new int?[] { 1, 3, 2, 4 };

      int?[][] solvedSudoku = SolveIt(sudoku);

      Assert.IsTrue(IsSolved(solvedSudoku));
    }

    [TestMethod]
    public void SolveIt_When_SudokuSolvable_2MissingEntries_InSameLine_ThenIsSolved()
    {

      int?[][] sudoku = new int?[4][];

      // Set the values of the first array in the jagged array structure.
      sudoku[0] = new int?[] { null, 1, null, 2 };
      sudoku[1] = new int?[] { 4, 2, 3, 1 };
      sudoku[2] = new int?[] { 2, 4, 1, 3 };
      sudoku[3] = new int?[] { 1, 3, 2, 4 };

      int?[][] solvedSudoku = SolveIt(sudoku);

      Assert.IsTrue(IsSolved(solvedSudoku));
    }

    [TestMethod]
    public void SolveIt_When_SudokuSolvable_3MissinEntries_InSameLine_ThenIsSolved()
    {

      int?[][] sudoku = new int?[4][];

      // Set the values of the first array in the jagged array structure.
      sudoku[0] = new int?[] { null, null, null, 2 };
      sudoku[1] = new int?[] { 4, 2, 3, 1 };
      sudoku[2] = new int?[] { 2, 4, 1, 3 };
      sudoku[3] = new int?[] { 1, 3, 2, 4 };

      int?[][] solvedSudoku = SolveIt(sudoku);

      Assert.IsTrue(IsSolved(solvedSudoku));
    }


    [TestMethod]
    public void IsSolved_When_InputIsCorrectlySolved_ThenIsSolved_True()
    {

      int?[][] solvedSudoku = new int?[4][];

      // Set the values of the first array in the jagged array structure.
      solvedSudoku[0] = new int?[] { 3, 1, 4, 2 };
      solvedSudoku[1] = new int?[] { 4, 2, 3, 1 };
      solvedSudoku[2] = new int?[] { 2, 4, 1, 3 };
      solvedSudoku[3] = new int?[] { 1, 3, 2, 4 };

      Assert.IsTrue(IsSolved(solvedSudoku));
    }

    [TestMethod]
    public void IsSolved_When_InputIsIncorrect_DuplicateInLine_ThenIsSolved_False()
    {

      int?[][] wrongSudoku = new int?[4][];

      // Set the values of the first array in the jagged array structure.
      wrongSudoku[0] = new int?[] { 4, 1, 4, 2 };
      wrongSudoku[1] = new int?[] { 4, 2, 3, 1 };
      wrongSudoku[2] = new int?[] { 2, 4, 1, 3 };
      wrongSudoku[3] = new int?[] { 1, 3, 2, 4 };

      Assert.IsFalse(IsSolved(wrongSudoku));
    }

    [TestMethod]
    public void IsSolved_When_InputIsIncorrect_DuplicateInRow_ThenIsSolved_False()
    {

      int?[][] wrongSudoku = new int?[4][];

      // Set the values of the first array in the jagged array structure.
      wrongSudoku[0] = new int?[] { 3, 1, 4, 2 };
      wrongSudoku[1] = new int?[] { 4, 2, 1, 3 };
      wrongSudoku[2] = new int?[] { 2, 4, 1, 3 };
      wrongSudoku[3] = new int?[] { 1, 3, 2, 4 };

      Assert.IsFalse(IsSolved(wrongSudoku));
    }

    [TestMethod]
    public void IsSolved_When_InputIsIncorrect_MissingEntry_ThenIsSolved_False()
    {

      int?[][] wrongSudoku = new int?[4][];

      // Set the values of the first array in the jagged array structure.
      wrongSudoku[0] = new int?[] { 3, 1, 4, 2 };
      wrongSudoku[1] = new int?[] { 4, 2, 3, 1 };
      wrongSudoku[2] = new int?[] { 2, 4, 1, null };
      wrongSudoku[3] = new int?[] { 1, 3, 2, 4 };

      Assert.IsFalse(IsSolved(wrongSudoku));
    }


    public bool IsSolved(int?[][] sudoku)
    {
      foreach (var line in sudoku)
      {
        if (!IsLineValid(line)) return false;
      }

      int?[][] sudokuTransposed = sudoku.SelectMany(inner => inner.Select((item, index) => new { item, index }))
      .GroupBy(i => i.index, i => i.item)
      .Select(g => g.ToArray())
      .ToArray();

      foreach (var line in sudokuTransposed)
      {
        if (!IsLineValid(line)) return false;
      }

      return true;
    }

    public int?[][] SolveIt(int?[][] sudoku)
    {
      int?[] lineArray = { 1, 2, 3, 4 };
      foreach (var line in sudoku)
      {
        for (int i = 0; i < line.Length; i++)
        {
          if (line[i] == null)
          {
            line[i] = lineArray.Except(line).First();
          }
        }
      }
      return sudoku;
    }

    public bool IsLineValid(int?[] line)
    {
      if (line.Any(number => number == null)) return false;
      if (line.Distinct().Count() != line.Count()) return false;
      if (line.Min() != 1) return false;
      if (line.Max() != line.Count()) return false;
      
      return true;

    }
  }
}
