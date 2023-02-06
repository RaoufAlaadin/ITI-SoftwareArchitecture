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

namespace _3_Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private string firstOperand = "";
        private string secondOperand = "";
        private string operation = "";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            if (textBox.Text == "0")
            {
                textBox.Text = b.Content.ToString();
            }
            else
            {
                textBox.Text += b.Content.ToString();
            }
        }

        private void Operation_Click(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            firstOperand = textBox.Text;
            operation = b.Content.ToString();
            textBox.Text = "0";
        }

        private void Equal_Click(object sender, RoutedEventArgs e)
        {
            secondOperand = textBox.Text;
            double num1, num2;
            if (double.TryParse(firstOperand, out num1) && double.TryParse(secondOperand, out num2))
            {
                switch (operation)
                {
                    case "+":
                        textBox.Text = (num1 + num2).ToString();
                        break;
                    case "-":
                        textBox.Text = (num1 - num2).ToString();
                        break;
                    case "*":
                        textBox.Text = (num1 * num2).ToString();
                        break;
                    case "/":
                        textBox.Text = (num1 / num2).ToString();
                        break;
                }
            }
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            textBox.Text = "0";
            firstOperand = "";
            secondOperand = "";
            operation = "";
        }
    }
}
