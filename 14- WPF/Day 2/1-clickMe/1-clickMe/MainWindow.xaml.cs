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

namespace _1_clickMe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private bool isLightBlueGradient = false;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            if (isLightBlueGradient)
            {
                btn.Background = (LinearGradientBrush)FindResource("GreyGradient");
                isLightBlueGradient = false;
            }
            else
            {
                btn.Background = (LinearGradientBrush)FindResource("LightBlueGradient");
                isLightBlueGradient = true;
            }
        }
    }
}
