using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Numerics;
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
    public partial class SelectionWindow : Window
    {
        public SelectionWindow(List<CategoryModel> fileContent)
        {
            InitializeComponent();
            ListCollection.ItemsSource = fileContent;
        }

        private void Button_Click_Preview(object sender, RoutedEventArgs e)
        {
            //Так как мы не можем выбрать все чекбоксы, потому что они созданы в темлейте, мы обращаемся к свойствам класса CheckBoxData в списке классов ExpandersInfo
            StringBuilder sb = new StringBuilder();

            foreach (var ExpInfo in (List<CategoryModel>)ListCollection.ItemsSource)
            {
                foreach (var checkboxData in ExpInfo.CheckBoxContent)
                {
                    //Берем только выбранные значения чекбоксов
                    if (checkboxData.IsSelected == true)
                    {
                        sb.AppendLine(checkboxData.Content);
                    }
                }
            }
            var w_PreviewWindow = new PreviewWindow(sb);
            w_PreviewWindow.Show();
            Hide();
        }


    }
}
