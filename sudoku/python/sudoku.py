from typing import List
from math import sqrt
from itertools import groupby


class Sudoku:
    def __init__(self, fields: List[List[int]]):
        self.width = len(fields)
        self.cell_width = sqrt(len(fields))
        self._fields = fields

    def row(self, index: int) -> List[int]:
        return list(self._fields[index])

    def column(self, index: int) -> List[int]:
        return list(map(lambda row: row[index], self._fields))

    def cell(self, y: int, x: int) -> List[int]:
        assert y < self.cell_width
        assert x < self.cell_width
        result = []
        for row in range(y*self.cell_width, (y+1)*self.cell_width):
            for col in range(x*self.cell_width, (x+1)*self.cell_width):
                result.append(self._fields[row][col])
        return result

    def __str__(self) -> str:
        pretty_rows: List[str] = []
        for i in range(int(self.cell_width ** 2)):
            str_row = map(str, self.row(i))
            pretty_rows.append(' '.join(str_row))
        return '\n'.join(pretty_rows)

    def is_valid(self) -> bool:
        for x in range(int(self.cell_width**2)):
            if not self.is_col_valid(x):
                return False
        for y in range(int(self.cell_width**2)):
            if not self.is_row_valid(y):
                return False
        for x in range(self.cell_width):
            for y in range(self.cell_width):
                if not self.is_cell_valid(x, y):
                    return False
        return True

    def _is_column_valid(self, x: int) -> bool:
        col = self.column(x)
        return len(col) == len(set(col))

    def _is_row_valid(self, y: int) -> bool:
        row = self.row(y)
        return len(row) == len(set(row))

    def _is_cell_valid(self, x: int, y: int) -> bool:
        cell = self.cell(x, y)
        return len(cell) == len(set(cell))
