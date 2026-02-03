using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suduku_project
{
    internal class SudokuBoard
    {
        private static int column = 9, row = 9;//
        private static char empty = '0';
        private int[,] Grid;// 
        private bool[,] IsInitial;//
                                  //for me [r,c]
        public SudokuBoard(string SudukuString)
        {
            Grid = new int[row, column];
            IsInitial = new bool[row, column];
            int charIndex = 0;
            if (SudukuString.Length == row * column)
            {
                for (int i = 0; i < row; i++)
                {
                    for (int j = 0; j < column; j++)
                    {
                        if (SudukuString[charIndex] != empty)
                        {
                            IsInitial[i, j] = true;
                            Grid[i, j] = int.Parse(SudukuString[charIndex].ToString());
                        }
                        charIndex++;
                    }
                }
            }
        }

        public int GetCell(int row, int col)
        {
            return Grid[row, col];
        }

        public void SetCell(int row, int col, int value)
        {
            Grid[row, col] = value;
        }

        public bool IsInitialCell(int row, int col)
        {
            return IsInitial[row, col];
        }

        // to do:ToFlattenedString

        public string ToFlattenedString()
        {
            string sudukuInstring = "";
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    sudukuInstring += Grid[i, j];
                }
            }
            return sudukuInstring;
        }
    }
}

