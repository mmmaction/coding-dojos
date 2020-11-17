from sudoku import Sudoku

demo_4x4_solved = [[4, 3, 1, 2], [2, 1, 3, 4], [1, 4, 2, 3], [3, 2, 4, 1]]


def test_prettify_is_even():
    sudoku = Sudoku(demo_4x4_solved)
    sudoku_lines = str(sudoku).splitlines()
    for line in sudoku_lines:
        assert len(line) == len(sudoku_lines[0])
    assert len(sudoku_lines) >= sudoku.width
    print()
    print(str(sudoku))
