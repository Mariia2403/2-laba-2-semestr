using System;

namespace Calculator
{
    class SubtractionCommand : ICommand
    {
        public CalculationOperations _operation;
        private long _previousResult;

        public SubtractionCommand(CalculationOperations operations)
        {
            _operation = operations;
        }
        public void Execute()
        {
            _previousResult = _operation.GetResult();

            _operation.Subtraction();
        }

        public void Undo()
        {
            _operation.SetResult(_previousResult);
        }
    }
}
