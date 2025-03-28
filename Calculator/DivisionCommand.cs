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
       
        private readonly double _a;
        private readonly double _b;
        public DivisionCommand(CalculationOperations operations, double a, double b) 
        {
        _operation = operations;
            _a = a;
            _b = b;
        }

        public void Execute()
        {
            if (_operation.CanDivide()) // Перевіряємо ділення на 0
            {
               
                _operation.SetValues(_a, _b);
                _operation.Division();

            }
        }

        public void Undo()
        {
            _operation.ReturnPreviousValue();
        }

        public void Redo()
        {
            Execute();
        }
    }
}
