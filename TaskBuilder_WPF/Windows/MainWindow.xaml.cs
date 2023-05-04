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

namespace TaskBuilder_WPF
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



        private void Button_Click_EscButton(object sender, RoutedEventArgs e)
        {
            this.Close(); // закрытие окна
        }

        private void Button_Click_Start2(object sender, RoutedEventArgs e)
        {
            var w_StartWindow2 = new StartWindow();
            w_StartWindow2.Show();
            Hide();
        }
    }
}
