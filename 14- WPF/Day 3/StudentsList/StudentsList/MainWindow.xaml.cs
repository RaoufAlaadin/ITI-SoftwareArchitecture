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
using WPFDay03;

namespace StudentsList
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Student> Students { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            Students = new List<Student>()
            {
                new Student(){Name="Ali",Id=10,Grade=200,Age =20, ImagePath="/img12.jpg"},
                new Student(){Name="Omar",Id=20,Grade=300,Age =18,ImagePath="/img13.jpg"},
                new Student(){Name="Anas",Id=30,Grade=400,Age =16,ImagePath="/img14.jpg"},
                new Student(){Name="Mai",Id=40,Grade=500,Age =22,ImagePath="/img15.jpg"},
                new Student(){Name="Mona",Id=50,Grade=600,Age =19,ImagePath="/img4.jpg"}


            };
            lst.ItemsSource = Students;

        }
    }
}
