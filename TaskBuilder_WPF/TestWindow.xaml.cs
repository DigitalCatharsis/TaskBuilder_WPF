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


        }
        //private void CheckBox_Checked(object sender, RoutedEventArgs e)
        //{
        //    MessageBox.Show(checkBox.Content.ToString() + " отмечен");
        //}

        //private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        //{
        //    MessageBox.Show(checkBox.Content.ToString() + " не отмечен");
        //}

        //private void CheckBox_Indeterminate(object sender, RoutedEventArgs e)
        //{
        //    MessageBox.Show(checkBox.Content.ToString() + " в неопределенном состоянии");
        //}

    }
}
