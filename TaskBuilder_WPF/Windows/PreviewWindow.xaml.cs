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
    /// Interaction logic for PreviewWindow.xaml
    /// </summary>
    public partial class PreviewWindow : Window
    {
        public PreviewWindow(StringBuilder result)
        {
            InitializeComponent();
            textBlock.Text = result.ToString();
        }

        private void Button_Click_Start2(object sender, RoutedEventArgs e)
        {
            var w_StartWindow2 = new StartWindow2();
            w_StartWindow2.Show();
            Hide();
        }
    }
}
