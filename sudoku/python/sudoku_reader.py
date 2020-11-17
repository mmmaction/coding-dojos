import csv


def read_csv(file_path, delim='\t'):
    values = []
    with open(file_path) as csvfile:
        sudoku_reader = csv.reader(csvfile, delimiter=delim)
        for row in sudoku_reader:
            line = []
            for item in row:
                try:
                    value = int(item)
                except ValueError:
                    value = None
                line.append(value)
            values.append(line)
    return values
