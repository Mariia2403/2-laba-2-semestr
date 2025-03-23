using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    internal class MultiplicationCommand: ICommand
    {
        CalculationOperations _operation;
        private long _previousResult;

        public MultiplicationCommand(CalculationOperations operations)
        {
        _operation = operations;
        }

        public void Execute()
        {
            _previousResult = _operation.GetResult();

            _operation.Multiplication();
        }

        public void Undo()
        {
            _operation.SetResult(_previousResult);
            }
    }
}
