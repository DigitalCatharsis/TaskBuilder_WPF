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
    public partial class TestWindow : Window
    {
        public DataInfo MyPhone { get; set; }
        public TestWindow()
        {
            InitializeComponent();

            MyPhone = new DataInfo
            {
                SubCategoryContent ="123",
                Category = "Lumia 630",
                SubCategoryNumber = "1000"
            };
            this.DataContext = MyPhone;
        }
    }
}