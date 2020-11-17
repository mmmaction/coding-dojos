from sudoku_reader import read_csv


def test_can_read():
    data = read_csv('testdata/4x4_full.txt')
    assert len(data) == 4
    assert len(data[0]) == 4
