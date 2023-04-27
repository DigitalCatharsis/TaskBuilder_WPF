using Microsoft.Win32;
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
using System.Windows.Shapes;

namespace TaskBuilder_WPF
{
    /// <summary>
    /// Interaction logic for TestWindow.xaml
    /// </summary>
    public partial class TestWindow : Window
    {
        public TestWindow()
        {
            InitializeComponent();

            // Create OpenFileDialog
        }

        //private void button1_Click(object sender, RoutedEventArgs e)
        //{
        //    // Create OpenFileDialog
        //    Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();

        //    // Set filter for file extension and default file extension
        //    dlg.DefaultExt = ".csv";
        //    dlg.Filter = "Csv Files (.csv)|*.csv";
        //    //dlg.InitialDirectory = каталог, который отображается при первом вызове окна

        //    // Display OpenFileDialog by calling ShowDialog method
        //    Nullable<bool> result = dlg.ShowDialog();

        //    // Get the selected file name and display in a TextBox
        //    if (result == true)
        //    {
        //        // Open document
        //        string filename = dlg.FileName;
        //        FileNameTextBox.Text = filename;
        //    }
        //}

    }
}
