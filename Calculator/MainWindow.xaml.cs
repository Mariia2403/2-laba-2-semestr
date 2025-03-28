using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows;

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double number1 = 0;
        double number2 = 0;
        double result;
        bool dec = false;


        private CalculationOperations _calculator;




        private readonly CommandInvoker _invoker = new CommandInvoker();


        string operation = "";
        public MainWindow()
        {
            InitializeComponent();

            _calculator = new CalculationOperations(0, 0, 0);

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
                    txtDisplay.Text = txtDisplay.Text + ",";

                }
                dec = false;
            }
            else
            {
                if (txtDisplay.Text.Equals("0") == true)
                {
                    txtDisplay.Text = numPressed.ToString();
                }

                else if (numPressed == "-" && txtDisplay.Text == "")
                {
                    txtDisplay.Text = "-";
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
            number1 = ParseSpecialInput(txtDisplay.Text);
            operation = "+";
            txtDisplay.Text = "";

        }
        private void btnMinus_Click(object sender, RoutedEventArgs e)
        {

            operation = "-";
            if (txtDisplay.Text != "")
            {
                number1 = ParseSpecialInput(txtDisplay.Text);
                txtDisplay.Text = "";
            }
            else
            {
                txtDisplay.Text = "-";
            }
        }

        private void btnTimes_Click(object sender, RoutedEventArgs e)
        {
            number1 = ParseSpecialInput(txtDisplay.Text);
            operation = "*";
            txtDisplay.Text = "";
        }

        private void btnDivide_Click(object sender, RoutedEventArgs e)
        {
            number1 = ParseSpecialInput(txtDisplay.Text);
            operation = "/";
            txtDisplay.Text = "";
        }

        private void btnEquals_Click(object sender, RoutedEventArgs e)
        {
           

            number2 = ParseSpecialInput(txtDisplay.Text);

            ICommand command = null;

            switch (operation)
            {

                case "+":

                  

                    command = new AddCommand(_calculator, number1, number2);
                  
                    break;
                case "-":

                  
                    command = new SubtractionCommand(_calculator, number1, number2);
                  

                    break;
                case "*":

                    command = new MultiplicationCommand(_calculator, number1, number2);
                  
                    break;
                case "/":

                    command = new DivisionCommand(_calculator, number1, number2);
                  
                    break;
            }
           
            if (command != null)
            {
                _invoker.Execute(command); // тепер керує виконанням і зберігає історію
                result = _calculator.GetResult();
                txtDisplay.Text = result.ToString();
            }
            else if (command == null)
            {
                result = ParseSpecialInput(txtDisplay.Text);
                txtDisplay.Text = result.ToString();
            }
        }
        private double ParseSpecialInput(string input)
        {
            input = input.Trim();
            input = input.Replace(',', '.');


            // Вставляємо * перед π, e, (
            input = Regex.Replace(input, @"(\d)(π)", "$1*π");
            input = Regex.Replace(input, @"(\d)(e)", "$1*e");
            input = Regex.Replace(input, @"(\d)\(", "$1*(");
            input = Regex.Replace(input, @"\)(\d)", ")*$1");
            input = Regex.Replace(input, @"\)(π)", ")*π");
            input = Regex.Replace(input, @"\)(e)", ")*e");

            // Заміна π та e
            input = input.Replace("π", Math.PI.ToString(System.Globalization.CultureInfo.InvariantCulture));
            input = input.Replace("e", Math.E.ToString(System.Globalization.CultureInfo.InvariantCulture));

            // Обробка ln(...)
            input = Regex.Replace(input, @"ln([a-zA-Z0-9.πe]+)", m =>
            {
                double val = EvaluateSimple(m.Groups[1].Value);
                return Math.Log(val).ToString(System.Globalization.CultureInfo.InvariantCulture);
            });

            // Обробка √(...)
            input = Regex.Replace(input, @"√([a-zA-Z0-9.πe]+)", m =>
            {
                double val = EvaluateSimple(m.Groups[1].Value);
                return Math.Sqrt(val).ToString(System.Globalization.CultureInfo.InvariantCulture);
            });

            // Обробка ^ (степінь)
            input = Regex.Replace(input, @"([0-9.]+)\^([0-9.]+)", m =>
            {
                double baseNum = double.Parse(m.Groups[1].Value);
                double exponent = double.Parse(m.Groups[2].Value);
                return Math.Pow(baseNum, exponent).ToString(System.Globalization.CultureInfo.InvariantCulture);
            });

            
            return EvaluateSimple(input);


        }
        private double EvaluateSimple(string expr)
        {
            var table = new System.Data.DataTable();
            return Convert.ToDouble(table.Compute(expr, ""));
        }

        private void btnClearEntry_Click(object sender, RoutedEventArgs e)
        {

            _invoker.UndoLast();
            txtDisplay.Text = _calculator.GetResult().ToString();
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            txtDisplay.Text = "";

            number1 = 0;
            number2 = 0;
            result = 0;
            operation = "";

            if (_calculator != null)
            {
                _calculator.SetResult(0);
               
            }

            _invoker?.ClearHistory();

        }

        private void btnBackspace_Click(object sender, RoutedEventArgs e)
        {
            int stringLength = txtDisplay.Text.Length;

            if (stringLength > 0)
            {
                txtDisplay.Text = txtDisplay.Text.Substring(0, stringLength - 1);
            }
            else
            {
                txtDisplay.Text = "";
            }
        }

        private void btnRedo_Click(object sender, RoutedEventArgs e)
        {
            _invoker.RedoLast();
            txtDisplay.Text = _calculator.GetResult().ToString();
        }

        private void btnTogglePanel_Click(object sender, RoutedEventArgs e)
        {
            if (AdvancedPanel.Visibility == Visibility.Visible)
            {
                AdvancedPanel.Visibility = Visibility.Collapsed; // Приховати
            }
            else
            {
                AdvancedPanel.Visibility = Visibility.Visible; // Показати
            }
        }
        private void btnPi_Click(object sender, RoutedEventArgs e)
        {
            txtDisplay.Text += "π";
           
        }
        private void btnE_Click(object sender, RoutedEventArgs e)
        {
            txtDisplay.Text += "e";
        }
        private void btnSqrt_Click(object sender, RoutedEventArgs e)
        {
            txtDisplay.Text += "√";
        }
        private void btnPower_Click(object sender, RoutedEventArgs e)
        {
            txtDisplay.Text += "^";
        }
        private void btnLn_Click(object sender, RoutedEventArgs e)
        {
            txtDisplay.Text += "ln";
        }
    }
}
