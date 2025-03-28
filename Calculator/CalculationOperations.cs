using System.Collections.Generic;

namespace Calculator
{
    class CalculationOperations
    {
        private double _currentValue;
        private double _currentValue2;
      
        private double _result;
        private Stack<double> _history = new Stack<double>(); // Історія результатів для Undo


        public CalculationOperations(double initialValue, double initialValue2, double result)
        {
            _currentValue = initialValue;
            _currentValue2 = initialValue2;
          
            _result = result;
            
        }
        public void SetValues(double value1, double value2)
        {
            _currentValue = value1;
            _currentValue2 = value2;
        }
      
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

        public double GetResult()
        {
            return _result;
        }
        public void SetResult(double value)
        {
            _result = value;
        }
        public void SaveToHistory()
        {
            _history.Push(_result);
        }
        public void ReturnPreviousValue()
        {
            if (_history.Count > 0)
            {
                _result = _history.Pop();
            }
        }
       

    }
}
