using System;

namespace Calculator
{
    //Reciever
    internal class AddCommand : ICommand
    {
        private CalculationOperations _operation;
        private readonly double _a;
        private readonly double _b;
     
        public AddCommand(CalculationOperations operation, double a, double b)
        {
            _operation = operation;
            _a = a;
            _b = b;
          
        }
        public void Execute()
        {
          
            _operation.SetValues(_a, _b);
            _operation.Addition();
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
