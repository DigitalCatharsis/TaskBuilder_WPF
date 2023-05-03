using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// </summary> /// 



    public partial class TestWindow : Window
    {
        public List<string> Categories { get; set; }
        //public List<string> phones;
        public TestWindow()
        {
            InitializeComponent();

            // phones = new List<string> { "iPhone 6S Plus", "Nexus 6P", "Galaxy S7 Edge" };
            Categories = new List<string> {"Hello","Task", "Result" };
            CategoryCollection.ItemsSource = Categories;



        }
    }
}