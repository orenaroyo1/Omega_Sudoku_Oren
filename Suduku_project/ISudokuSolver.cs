using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suduku_project
{
    internal interface ISudokuSolver
    {
        bool Solve(SudokuBoard board);
    }
}
