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
using TaskBuilder_WPF.Classes;

namespace TaskBuilder_WPF
{
    /// <summary>
    /// Interaction logic for TestWindow.xaml
    /// </summary>
    /// 
    public class Phone : DependencyObject
    {
        public static readonly DependencyProperty TitleProperty;
        public static readonly DependencyProperty PriceProperty;

        static Phone()
        {
            TitleProperty = DependencyProperty.Register("Title", typeof(string), typeof(Phone));
            PriceProperty = DependencyProperty.Register("Price", typeof(int), typeof(Phone));
        }
        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }
        public int Price
        {
            get { return (int)GetValue(PriceProperty); }
            set { SetValue(PriceProperty, value); }
        }
    }

    public partial class TestWindow : Window
    {
        public DataInfo MyPhone { get; set; }
        public TestWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Phone phone = (Phone)this.Resources["iPhone6s"]; // получаем ресурс по ключу
            MessageBox.Show(phone.Price.ToString());
        }
    }
}