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

namespace _2_Form
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string fullName = FirstNameTextBox.Text + " " + LastNameTextBox.Text;
            string gender = GenderTextBox.Text;
            string address = AddressTextBox.Text;
            string phone = PhoneTextBox.Text;
            string mobile = MobileTextBox.Text;
            string email = EmailTextBox.Text;
            string jobTitle = JobTitleTextBox.Text;

            MessageBoxResult result = MessageBox.Show($"Full Name: {fullName}\nGender: {gender}\nAddress: {address}\nPhone: {phone}\nMobile: {mobile}\nEmail: {email}\nJob Title: {jobTitle}\n\nSave data?", "Save Data", MessageBoxButton.YesNo);

            if (result == MessageBoxResult.Yes)
            {
                MessageBox.Show("Data saved successfully");
            }
            else
                Button_Click_1(sender,e);


        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            FirstNameTextBox.Text = "";
            LastNameTextBox.Text = "";
            GenderTextBox.Text = "";
            AddressTextBox.Text = "";
            PhoneTextBox.Text = "";
            MobileTextBox.Text = "";
            EmailTextBox.Text = "";
            JobTitleTextBox.Text = "";

            // Show a message indicating that all input data has been cleared
            MessageBox.Show("All input data cleared");
        }
    }
}
