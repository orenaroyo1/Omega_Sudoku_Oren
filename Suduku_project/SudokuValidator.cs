using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suduku_project
{
    internal static class SudokuValidator
    {
        private const int BoardSize = 81;//Sudoku board size
        //Checks if the input is correct and legal, the size is correct and there are only numbers between 0-9
        public static bool IsValidFormat(string SudokuString)
        {
            if (string.IsNullOrEmpty(SudokuString) || SudokuString.Length != BoardSize)
            {
                return false;
            }

            foreach (char c in SudokuString)
            {
                if (c < '0' || c > '9')
                {
                    return false;
                }
            }

            return true;
        }
        //Checks whether the Sudoku board it received is legal in terms of duplicate numbers
        public static bool IsBoardLegal(string SudokuString)
        {
            int[] rows = new int[9];
            int[] cols = new int[9];
            int[] boxes = new int[9];

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    int charIndex = i * 9 + j;
                    int val = SudokuString[charIndex] - '0';

                    if (val > 0)
                    {
                        int boxIndex = (i / 3) * 3 + (j / 3);
                        int mask = 1 << (val - 1); 

                        if ((rows[i] & mask) != 0 || (cols[j] & mask) != 0 || (boxes[boxIndex] & mask) != 0)
                        {
                            return false; 
                        }

                        rows[i] |= mask;
                        cols[j] |= mask;
                        boxes[boxIndex] |= mask;
                    }
                }
            }

            return true;
        }
    }
}