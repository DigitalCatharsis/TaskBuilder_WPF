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
    public partial class SelectionWindow3 : Window
    {
        public List<ExpandersInfo> FileContent { get; init; }
        public SelectionWindow3(List<DataInfo> fileContent)
        {
            InitializeComponent();

            var tempDataInfo3 = new ExpandersInfo()
            {
                CategoryName = "Task",
                CheckBoxContent = new ObservableCollection<CheckBoxData>
            {
                new CheckBoxData { Content = "Content1", IsSelected = false },

                new CheckBoxData { Content = "Content2", IsSelected = true, },

                new CheckBoxData { Content = "Content3", IsSelected = false, }
            }
            };

            var tempDataInfo4 = new ExpandersInfo()
            {
                CategoryName = "Result",
                CheckBoxContent = new ObservableCollection<CheckBoxData>
            {
                new CheckBoxData { Content = "Result1", IsSelected = false },

                new CheckBoxData { Content = "Result2", IsSelected = true, },

                new CheckBoxData { Content = "Result3", IsSelected = false, }
            }
            };
            var tempResult = new ObservableCollection<ExpandersInfo> { tempDataInfo3, tempDataInfo4 };
            ListCollection.ItemsSource = tempResult;
        }

        //private List<ExpandersInfo> FileContentToExpandersInfos(List<DataInfo> fileContent)
        //{
        //    var list = new List<ExpandersInfo>();
        //    return list;
        //}

        private void Button_Click_Preview(object sender, RoutedEventArgs e)
        {
            //Так как мы не можем выбрать все чекбоксы, потому что они созданы в темлейте, мы обращаемся к свойствам класса CheckBoxData в списке классов ExpandersInfo
            StringBuilder sb = new StringBuilder();

            foreach (var ExpInfo in (ObservableCollection<ExpandersInfo>)ListCollection.ItemsSource)
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
