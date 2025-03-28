using System.Collections.Generic;

namespace Calculator
{
    internal class CommandInvoker
    {
        private Stack<ICommand> _undoHistory = new Stack<ICommand>();
        private Stack<ICommand> _redoHistory = new Stack<ICommand>();
        public void Execute(ICommand command)
        {
            command.Execute();
            _undoHistory.Push(command);
            _redoHistory.Clear();
            
        }

        public void UndoLast()
        {

            if (_undoHistory.Count > 0)
            {
                var command = _undoHistory.Pop();
                command.Undo();
                _redoHistory.Push(command);
              
            }
        }
        public void RedoLast()
        {
            if (_redoHistory.Count > 0)
            {
                var command = _redoHistory.Pop();
                command.Redo(); 
                _undoHistory.Push(command);
            }
        }
        public void ClearHistory()
        {
            _undoHistory.Clear();
        }
    }
}
