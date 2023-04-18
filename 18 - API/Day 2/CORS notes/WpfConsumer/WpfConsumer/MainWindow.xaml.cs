using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;

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

namespace WpfConsumer
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

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
                // Get data from service provider http://localhost:38931/api/Department

           HttpClient httpClient = new HttpClient();

            HttpResponseMessage response = await httpClient.GetAsync("http://localhost:38931/api/Department");
            if (response.IsSuccessStatusCode)
            {
                string msg = await response.Content.ReadAsStringAsync();

                // "!" means , don't  worry it will never be null.
                //List<Department> DeptList = JsonSerializer.Deserialize<List<Department>>(msg)!;

                List<Department> DeptList = JsonSerializer.Deserialize<List<Department>>(msg)?? 
                    new List<Department>(); // returns empty list if deserialize result in null.


                DeptListItem.ItemsSource = DeptList;    
            }
            else
            {
                MessageBox.Show("try Again");
            }

        }

        private void DeptListItem_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Department dept = (Department) DeptListItem.SelectedItem ;


        }
    }
}
