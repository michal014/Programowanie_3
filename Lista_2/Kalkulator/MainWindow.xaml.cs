using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Kalkulator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string number1 = null;
        string number2 = null;
        string sign = null;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Number_Click(object sender, RoutedEventArgs e)
        {
            if (sign == null && number1 == null)
            {
                number1=(((Button)sender).Tag).ToString();
                display.Content = number1;
            }
            else if (sign == null && number1 != null)
            {
                if (number1 == "0" && (((Button)sender).Tag).ToString() == ",")
                {
                    number1 = number1 + (((Button)sender).Tag).ToString();
                    display.Content = number1;
                }
                else if (number1 == "0" && (((Button)sender).Tag).ToString() != "0")
                {
                    number1 = (((Button)sender).Tag).ToString();
                    display.Content = number1;
                }
                else if (number1 != "0")
                {
                    number1 = number1 + (((Button)sender).Tag).ToString();
                    display.Content = number1;
                }
            }
            else if (sign != null && number2 == null)
            {
                number2 = (((Button)sender).Tag).ToString();
                display.Content = number2;
            }
            else if (sign != null && number2 != null)
            {
                if (number2 == "0" && (((Button)sender).Tag).ToString() == ",")
                {
                    number2 = number2 + (((Button)sender).Tag).ToString();
                    display.Content = number2;
                }
                else if (number2 == "0" && (((Button)sender).Tag).ToString() != "0")
                {
                    number2 = (((Button)sender).Tag).ToString();
                    display.Content = number2;
                }
                else if (number2 != "0")
                {
                    number2 = number2 + (((Button)sender).Tag).ToString();
                    display.Content = number2;
                }
            }
        }

        private void Add(object sender, RoutedEventArgs e)
        {
            if (sign == null)
            {
                sign = "+";
                display.Content = "0";
            }
            else if (sign == "+")
            {
                number1 = Convert.ToString(Convert.ToDouble(number1) + Convert.ToDouble(number2));
                number2 = null;
                display.Content = "0";
            }
        }

        private void Sub(object sender, RoutedEventArgs e)
        {
            if (sign == null)
            {
                sign = "-";
                display.Content = "0";
            }
            else if (sign == "-")
            {
                number1 = Convert.ToString(Convert.ToDouble(number1) - Convert.ToDouble(number2));
                number2 = null;
                display.Content = "0";
            }
        }

        private void Mul(object sender, RoutedEventArgs e)
        {
            if (sign == null)
            {
                sign = "*";
                display.Content = "0";
            }
            else if (sign == "*")
            {
                number1 = Convert.ToString(Convert.ToDouble(number1) * Convert.ToDouble(number2));
                number2 = null;
                display.Content = "0";
            }
        }

        private void Div(object sender, RoutedEventArgs e)
        {
            if (sign == null)
            {
                sign = "/";
                display.Content = "0";
            }
            else if (sign == "/" && number2 != "0")
            {
                number1 = Convert.ToString(Convert.ToDouble(number1) / Convert.ToDouble(number2));
                number2 = null;
                display.Content = "0";
            }
            else if (sign == "/" && number2 == "0")
            {
                display.Content = "BŁĄD";
                number1 = null;
                number2 = null;
                sign = null;
            }
        }

        private void Clean(object sender, RoutedEventArgs e)
        {
            display.Content = "0";
            number1 = null;
            number2 = null;
            sign = null;
        }

        private void Result(object sender, RoutedEventArgs e)
        {
            if (sign == "+")
            {
                number1 = Convert.ToString(Math.Round(Convert.ToDouble(number1) + Convert.ToDouble(number2),10));
                number2 = null;
                sign = null;
                display.Content = number1;
            }
            else if (sign == "-")
            {
                number1 = Convert.ToString(Math.Round(Convert.ToDouble(number1) - Convert.ToDouble(number2),10));
                number2 = null;
                sign = null;
                display.Content = number1;
            }
            else if (sign == "*")
            {
                number1 = Convert.ToString(Math.Round(Convert.ToDouble(number1) * Convert.ToDouble(number2),10));
                number2 = null;
                sign = null;
                display.Content = number1;
            }
            else if (sign == "/" && number2 != "0")
            {
                number1 = Convert.ToString(Math.Round(Convert.ToDouble(number1) / Convert.ToDouble(number2),10));
                number2 = null;
                sign = null;
                display.Content = number1;
            }
            else if (sign == "/" && number2 == "0")
            {
                display.Content = "BŁĄD";
                number1 = null;
                number2 = null;
                sign = null;
            }
        }

    }
}
