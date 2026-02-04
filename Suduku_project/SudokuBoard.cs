using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suduku_project
{
    internal class SudokuBoard
    {
        private static int column = 9, row = 9;//Static final variables for Sudoku size
        private static char empty = '0';
        private int[,] Grid;// A matrix that will hold the Sudoku
        private bool[,] IsInitial;//A matrix that preserves the original values
                                  //for me [r,c]

        //Constructor operation that converts Sudoku from a string to a matrix
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
        //One cell value
        public int GetCell(int row, int col)
        {
            return Grid[row, col];
        }
        //Definition of one cell
        public void SetCell(int row, int col, int value)
        {
            Grid[row, col] = value;
        }

        public bool IsInitialCell(int row, int col)
        {
            return IsInitial[row, col];
        }

        // to do:ToFlattenedString
        //Converts it back to a string

        public string ToFlattenedString()
        {
            string sudukuInstring = "";
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    sudukuInstring += Grid[i, j];
                }
            }
            return sudukuInstring;
        }
        //Printing Sudoku with user UI
        public void PrintBoard()
        {
            Console.WriteLine("-------------------------");
            for (int i = 0; i < row; i++)
            {
                if (i % 3 == 0 && i != 0)
                {
                    Console.WriteLine("|-------+-------+-------|");
                }

                for (int j = 0; j < column; j++)
                {
                    if (j % 3 == 0)
                    {
                        Console.Write("| ");
                    }

                    if (Grid[i, j] == 0)
                        Console.Write(". ");
                    else
                        Console.Write(Grid[i, j] + " ");
                }
                Console.WriteLine("|"); 
            }
            Console.WriteLine("-------------------------");
        }
        //Deleting the Sudoku
        public void ClearBoard()
        {
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    if (!IsInitial[i, j])
                    {
                        Grid[i, j] = 0;
                    }
                }
            }
        }
    }
}

