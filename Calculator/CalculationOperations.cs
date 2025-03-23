using System.Collections.Generic;

namespace Calculator
{
    class CalculationOperations
    {
        private long _currentValue;
        private long _currentValue2;
        //   private string _operand;
        private long _result;
        private Stack<long> _history = new Stack<long>(); // Історія результатів для Undo


        public CalculationOperations(long initialValue, long initialValue2, long result)
        {
            _currentValue = initialValue;
            _currentValue2 = initialValue2;
            // _operand = operand;
            _result = result;
            
        }
        /* public void SetOperand(double operand)
         {
             _operand = operand;
         }*/

        public void Addition()
        {
            SaveToHistory();
            _result = _currentValue + _currentValue2;

        }
        public void Subtraction()
        {
            SaveToHistory();
            _result = _currentValue - _currentValue2;

        }

        public void Multiplication()
        {
            SaveToHistory();
            _result = _currentValue * _currentValue2;
        }
        public void Division()
        {
            if (_currentValue2 != 0)
            {
                SaveToHistory();
                _result = _currentValue / _currentValue2;
            }
        }
        public bool CanDivide()
        {
            return _currentValue2 != 0; // Повертає true, якщо дільник НЕ дорівнює 0
        }

        public long GetResult()
        {
            return _result;
        }
        public void SetResult(long value)
        {
            _result = value;
        }
        private void SaveToHistory()
        {
            _history.Push(_result);
        }


    }
}
