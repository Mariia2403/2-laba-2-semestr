using System;

namespace Calculator
{
    class SubtractionCommand : ICommand
    {
        public CalculationOperations _operation;
     
        private readonly double _a;
        private readonly double _b;

        public SubtractionCommand(CalculationOperations operations, double a, double b)
        {
            _operation = operations;
            _a = a;
            _b = b;
        }
        public void Execute()
        {
          
            _operation.SetValues(_a, _b);
            _operation.Subtraction();
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
