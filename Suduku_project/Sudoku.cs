using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Suduku_project
{
    internal class Sudoku
    {
        private SudokuBoard board;//
        private BacktrackingSolver solver;//
        private Stopwatch sw;

        public Sudoku()
        {
            solver = new BacktrackingSolver();
            sw = new Stopwatch();
        }
        //
        public void SolveFromRawString(string sudokuString)
        {
            if (!SudokuValidator.IsValidFormat(sudokuString))
            {
                Console.WriteLine("Error: Invalid format! String must be 81 digits (0-9).");
                return;
            }
            //
            if (!SudokuValidator.IsBoardLegal(sudokuString))
            {
                Console.WriteLine("Error: The board is illegal! Duplicate numbers found in a row, column, or 3x3 box.");
                return;
            }
            sw.Start();
            board = new SudokuBoard(sudokuString);

            Console.WriteLine("--- The received board ---");
            board.PrintBoard();

            Console.WriteLine("\nTrying to solve...");

            if (solver.Solve(board))
            {
                Console.WriteLine("--- The final solution ---");
                board.PrintBoard();
            }
            else
            {
                Console.WriteLine("Sorry, no legal solution was found for this board.");
            }
            sw.Stop();
            TimeSpan ts = sw.Elapsed;
            Console.WriteLine($"Seconds:      {ts.TotalSeconds:F2}s");
            Console.WriteLine($"Time elapsed: {ts.TotalMilliseconds} ms");
        }
    }
}