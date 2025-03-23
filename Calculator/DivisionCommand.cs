using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    internal class DivisionCommand :ICommand
    {
        CalculationOperations _operation;
        private long _previousResult;

        public DivisionCommand(CalculationOperations operations) 
        {
        _operation = operations;
        }

        public void Execute()
        {
            if (_operation.CanDivide()) // Перевіряємо ділення на 0
            {
                _previousResult = _operation.GetResult();
                _operation.Division();
            }
        }

        public void Undo()
        {
            _operation.SetResult(_previousResult);
        }
    }
}
