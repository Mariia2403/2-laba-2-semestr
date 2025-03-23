using System.Windows;

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        long number1 = 0;
        long number2 = 0;
        long result;
        bool dec = false;

        private CalculationOperations _calculator;
        private ICommand _addCommand;
        //private ICommand _equalsCommand;
        private ICommand _substractionCommand;
        private ICommand _multiplicationCommand;
        private ICommand _DivisionCommand;

        string operation = "";
        public MainWindow()
        {
            InitializeComponent();
            // _calculator = new CalculationOperations(0);
            btnDivide.Content = "\u00F7";
        }


        private void ChangeLabel(string numPressed)
        {
            if (dec == true)//If true it means user to press the btnDot
            {
                int decimalCount = 0;
                foreach (char c in txtDisplay.Text)
                {
                    if (c == '.')//We check if "dot" already exists  
                    {
                        decimalCount++;
                    }

                }
                if (decimalCount < 1)
                {
                    txtDisplay.Text = txtDisplay.Text + ".";

                }
                dec = false;
            }
            else
            {

                if (txtDisplay.Text.Equals("0") == true && txtDisplay.Text != null)
                {
                    txtDisplay.Text = numPressed.ToString();
                }
                else if (txtDisplay.Text.Equals("-0") == true)
                {
                    txtDisplay.Text = "-" + numPressed.ToString();
                }
                else if (numPressed == "00")
                {
                    txtDisplay.Text += numPressed;
                }
                else
                {
                    txtDisplay.Text = txtDisplay.Text + numPressed.ToString();
                }

            }
        }

        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            ChangeLabel("1");
        }

        private void btn2_Click(object sender, RoutedEventArgs e)
        {
            ChangeLabel("2");
        }

        private void btn3_Click(object sender, RoutedEventArgs e)
        {
            ChangeLabel("3");
        }

        private void btn4_Click(object sender, RoutedEventArgs e)
        {
            ChangeLabel("4");
        }

        private void btn5_Click(object sender, RoutedEventArgs e)
        {
            ChangeLabel("5");
        }

        private void btn6_Click(object sender, RoutedEventArgs e)
        {
            ChangeLabel("6");
        }

        private void btn7_Click(object sender, RoutedEventArgs e)
        {
            ChangeLabel("7");
        }

        private void btn8_Click(object sender, RoutedEventArgs e)
        {
            ChangeLabel("8");
        }

        private void btn9_Click(object sender, RoutedEventArgs e)
        {
            ChangeLabel("9");
        }

        private void btn0_Click(object sender, RoutedEventArgs e)
        {
            ChangeLabel("0");
        }

        private void btn00_Click(object sender, RoutedEventArgs e)
        {
            ChangeLabel("00");
        }

        private void btnDot_Click(object sender, RoutedEventArgs e)
        {
            dec = true;
            ChangeLabel("0");
        }

        private void btnPlus_Click(object sender, RoutedEventArgs e)
        {
            number1 = long.Parse(txtDisplay.Text);
            operation = "+";
            txtDisplay.Text = "";

        }
        private void btnMinus_Click(object sender, RoutedEventArgs e)
        {
            number1 = long.Parse(txtDisplay.Text);
            operation = "-";
            txtDisplay.Text = "";
        }

        private void btnTimes_Click(object sender, RoutedEventArgs e)
        {
            number1 = long.Parse(txtDisplay.Text);
            operation = "*";
            txtDisplay.Text = "";
        }

        private void btnDivide_Click(object sender, RoutedEventArgs e)
        {
            number1 = long.Parse(txtDisplay.Text);
            operation = "/";
            txtDisplay.Text = "";
        }

        private void btnEquals_Click(object sender, RoutedEventArgs e)
        {
            result = 0;
            if (txtDisplay.Text.Equals("0") == false)
            {
                switch (operation)
                {
                    case "+":
                        number2 = long.Parse(txtDisplay.Text);
                        _calculator = new CalculationOperations(number1, number2, result);
                        _addCommand = new AddCommand(_calculator);
                        _addCommand.Execute();

                        break;
                    case "-":
                        number2 = long.Parse(txtDisplay.Text);
                        _calculator = new CalculationOperations(number1, number2, result);
                        _substractionCommand = new SubtractionCommand(_calculator);
                        _substractionCommand.Execute();

                        break;
                    case "*":
                        number2 = long.Parse(txtDisplay.Text);
                        _calculator = new CalculationOperations(number1, number2, result);
                        _multiplicationCommand = new MultiplicationCommand(_calculator);
                        _multiplicationCommand.Execute();

                        break;
                    case "/":
                        number2 = long.Parse(txtDisplay.Text);
                        _calculator = new CalculationOperations(number1, number2, result);
                        _DivisionCommand = new DivisionCommand(_calculator);
                        _DivisionCommand.Execute();
                        break;
                }
                result = _calculator.GetResult();
                txtDisplay.Text = result.ToString();
            }
        }

        private void btnClearEntry_Click(object sender, RoutedEventArgs e)
        {
            if (_addCommand != null) _addCommand.Undo();
            if (_substractionCommand != null) _substractionCommand.Undo();
            if (_multiplicationCommand != null) _multiplicationCommand.Undo();
            if (_DivisionCommand != null) _DivisionCommand.Undo();

            txtDisplay.Text = _calculator.GetResult().ToString();
        }
    }
}
