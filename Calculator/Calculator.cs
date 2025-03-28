using System.Collections.Generic;

namespace Calculator
{
    //invoker
    public class Calc
    {
        private int _currentValue;
        private Stack<ICommand> _undoStack = new Stack<ICommand>();
        private Stack<ICommand> _redoStack = new Stack<ICommand>();

        public int CurrentValue => _currentValue;

        public void SetValue(int value)
        {
            _currentValue = value;
        }

        public void ExecuteCommand(ICommand command)
        {
            command.Execute();
            _undoStack.Push(command);
            _redoStack.Clear(); //Clear Redo after new event
        }

    }
}
