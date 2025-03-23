using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    internal class EqualsCommand : ICommand
    {
        CalculationOperations _operations;

        public EqualsCommand(CalculationOperations operations)
        {
            _operations = operations;
        }

        public void Execute()
        {
        }

        public void Undo()
        {
            throw new NotImplementedException();
        }
    }
}
