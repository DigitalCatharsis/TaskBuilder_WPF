using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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

namespace TaskBuilder_WPF.Windows
{

    public partial class Window1 : Window
    {

        public Window1()
        {
            InitializeComponent();

        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox cb = (CheckBox)sender;
            for (int i = 0; i < lb.Items.Count; i++)
            {
                CheckBox checkBox = (CheckBox)lb.SelectedItem;

                bool same = checkBox == cb;
                // this will uncheck checkboxes that were previously checked
                checkBox.IsChecked = same;

                if (same)
                {
                    lb.SelectedIndex = i;
                }
            }
        }

        private void lb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CheckBox cb = lb.SelectedItem as CheckBox;

            foreach (CheckBox item in lb.Items)
            {
                item.IsChecked = cb == item;
            }
        }
    }
}