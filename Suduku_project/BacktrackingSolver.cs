using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suduku_project
{
    internal class BacktrackingSolver : ISudokuSolver
    {
        //
        public bool Solve(SudokuBoard board)
        {
            int row = 0, col = 0;
            
            if (!GetNextEmptyCell(board, ref row, ref col))
            {
                return true; 
            }

            for (int num = 1; num <= 9; num++)
            {
                if (IsLegalPlacement(board, row, col, num))
                {
                    board.SetCell(row, col, num); 

                    if (Solve(board)) return true; 

                    board.SetCell(row, col, 0); 
                }
            }

            return false;
        }
        //
        private bool GetNextEmptyCell(SudokuBoard board, ref int r, ref int c)
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (board.GetCell(i, j) == 0)
                    {
                        r = i;
                        c = j;
                        return true;
                    }
                }
            }
            return false;
        }

        // 
        private bool IsLegalPlacement(SudokuBoard board, int row, int col, int num)
        {
            return !UsedInRow(board, row, num) &&
                   !UsedInCol(board, col, num) &&
                   !UsedInBox(board, row - row % 3, col - col % 3, num);
        }

        // 
        private bool UsedInRow(SudokuBoard board, int row, int num)
        {
            for (int i = 0; i < 9; i++)
                if (board.GetCell(row, i) == num) return true;
            return false;
        }

        //
        private bool UsedInCol(SudokuBoard board, int col, int num)
        {
            for (int i = 0; i < 9; i++)
                if (board.GetCell(i, col) == num) return true;
            return false;
        }

        // 
        private bool UsedInBox(SudokuBoard board, int boxStartRow, int boxStartCol, int num)
        {
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    if (board.GetCell(boxStartRow + i, boxStartCol + j) == num)
                        return true;
            return false;
        }
    }
}
