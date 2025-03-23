using System;

namespace Calculator
{
    //Reciever
    internal class AddCommand : ICommand
    {
        private CalculationOperations _operation;
        private long _previousResult; // Збереження попереднього результату

        // private string _operand;
        public AddCommand(CalculationOperations operation)
        {
            _operation = operation;
           // _operand = operand;
        }
        public void Execute()
        {
            // numForOperation.SetOperand(_operand);
            _previousResult = _operation.GetResult(); // Зберігаємо попередній стан

            _operation.Addition();
        }

        public void Undo()
        {
            _operation.SetResult(_previousResult); // Повертаємо попереднє значення
        }
    }
}
