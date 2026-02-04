using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suduku_project
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Sudoku game = new Sudoku();
            string input = "";

            Console.WriteLine("=== Sudoku Solver System ===");
            Console.WriteLine("Enter a 81-digit Sudoku string (or type '-1' to exit):");
            input = Console.ReadLine();
            while (input != "-1")
            {
                
                
                game.SolveFromRawString(input);

                Console.WriteLine("\nEnter another Sudoku string or '-1' to exit:");
                Console.Write("\nInput: ");
                input = Console.ReadLine();

            }
        }
    }
}
