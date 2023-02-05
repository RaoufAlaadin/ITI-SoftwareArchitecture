using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _1_DrawingCanvas
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

        /* We use Content to reach the content we wrote in the button as an Identifier
           and I think ToString() is just to make sure we got a string value from it?
        */
        private void Change_Color(object sender, RoutedEventArgs e)
        {
            RadioButton radioButton = sender as RadioButton;
            if (radioButton == null)
                return;

            switch (radioButton.Content.ToString())
            {
                case "Red":

                    InkCan.DefaultDrawingAttributes.Color = Colors.Red;
                    break;

                case "Green":

                    InkCan.DefaultDrawingAttributes.Color = Colors.Green;
                    break;

                case "Blue":

                    InkCan.DefaultDrawingAttributes.Color = Colors.Blue;
                    break;
                case "Magenta":
                    InkCan.DefaultDrawingAttributes.Color = Colors.Magenta;
                    break;
            }
        }

        private void Change_Mode(object sender, RoutedEventArgs e)
        {
            RadioButton radioButton = sender as RadioButton;
            if (radioButton == null)
                return;

            switch (radioButton.Content.ToString())
            {
                case "Ink":

                    InkCan.EditingMode = InkCanvasEditingMode.Ink;
                    break;

                case "Select":

                    InkCan.EditingMode = InkCanvasEditingMode.Select;
                    break;

                case "Erase":

                    InkCan.EditingMode = InkCanvasEditingMode.EraseByPoint;
                    break;

                case "Erase by strock":

                    InkCan.EditingMode = InkCanvasEditingMode.EraseByStroke;
                    break;
            }
        }

        private void Change_Shape(object sender, RoutedEventArgs e)
        {
            RadioButton radioButton = sender as RadioButton;
            if (radioButton == null)
                return;

            switch (radioButton.Content.ToString())
            {
                case "Ellipse":

                    InkCan.DefaultDrawingAttributes.StylusTip = StylusTip.Ellipse;
                    break;

                case "Rectangle":

                    InkCan.DefaultDrawingAttributes.StylusTip = StylusTip.Rectangle;
                    break;
            }
        }

        private void Change_BrushSize(object sender, RoutedEventArgs e)
        {
            RadioButton radioButton = sender as RadioButton;
            if (radioButton == null)
                return;

            switch (radioButton.Content.ToString())
            {
                case "Small":

                    InkCan.DefaultDrawingAttributes.Width = 2;
                    InkCan.DefaultDrawingAttributes.Height = 2;
                    break;

                case "Normal":

                    InkCan.DefaultDrawingAttributes.Width = 4;
                    InkCan.DefaultDrawingAttributes.Height = 4;
                    break;

                case "Large":

                    InkCan.DefaultDrawingAttributes.Width = 8;
                    InkCan.DefaultDrawingAttributes.Height = 8;
                    break;
            }
        }

        private void Button_New_Click(object sender, RoutedEventArgs e)
        {
            InkCan.Strokes.Clear();
        }

        private void Button_Save_Click(object sender, RoutedEventArgs e)
        {
            // create a new saveFileDialog object
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            /* https://learn.microsoft.com/en-us/dotnet/api/system.windows.forms.filedialog.filter?redirectedfrom=MSDN&view=windowsdesktop-7.0#System_Windows_Forms_FileDialog_Filter*/
            
            // Filter out un-used file extensions 
            saveFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";

            // open the dialog window and return true if it opened successfully. 
            if (saveFileDialog.ShowDialog() == true)
            {
                // the using statement, ensures that filestream is properly closed and any asscoitated resources 
                // are cleaned up .. this prevents resource leakage
                // also if any exception happens inside this block, it won't effect the run of the rest of the program. 
                using (
                    FileStream fileStream = new FileStream(saveFileDialog.FileName, FileMode.Create)
                )
                {
                    // saves our canvas strokes to a specific file.
                    InkCan.Strokes.Save(fileStream);
                }
            }
        }

        private void Button_Load_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                using (
                    FileStream fileStream = new FileStream(openFileDialog.FileName, FileMode.Open)
                )
                {
                    StrokeCollection strokes = new StrokeCollection(fileStream);
                    InkCan.Strokes = strokes;
                }
            }
        }

        private void Button_Copy_Click(object sender, RoutedEventArgs e)
        {
            InkCan.CopySelection();
        }

        private void Button_Cut_Click(object sender, RoutedEventArgs e)
        {
            InkCan.CutSelection();

        }


        int x = 30;
        int y = 50;
        private void Button_Paste_Click(object sender, RoutedEventArgs e)
        {
            x += 10;
            y += 10;
            InkCan.Paste(new Point{ X= x,Y= y});

                // set a limit to reset the paste location.

        }
    }
}
