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
    /// <summary>
    /// Interaction logic for SelectionWindow2.xaml
    /// </summary>
    /// 

    public partial class SelectionWindow3 : Window
    {
        public List<ExpandersInfo> FileContent { get; init; }
        public SelectionWindow3(List<DataInfo> fileContent)
        {
            InitializeComponent();
            //var expanderInfoList = FileContentToExpandersInfos(fileContent);

            var tempDataInfo1 = new ExpandersInfo() {CategoryName = "Hello1", CategoryContent = new ObservableCollection<string> { "HelloCont1",  "HelloCont2", "HelloCont3"} };
            var tempDataInfo2 = new ExpandersInfo() {CategoryName = "Task", CategoryContent = new ObservableCollection<string> { "Task1", "Task2", "Task3" } };
            var tempDataInfo3 = new ExpandersInfo() {CategoryName = "Result", CategoryContent = new ObservableCollection<string> { "Result1", "Result2", "Result3" } };
            var tempResult = new ObservableCollection<ExpandersInfo> { tempDataInfo1, tempDataInfo2, tempDataInfo3 };
            ListCollection.ItemsSource = tempResult;



        }



        private List<ExpandersInfo> FileContentToExpandersInfos(List<DataInfo> fileContent)
        {
            var list = new List<ExpandersInfo>();
            return list;
        }

        private void Button_Click_Preview(object sender, RoutedEventArgs e)
        {
            var result = new StringBuilder();
            //var list = (this.Content as Grid).Children.OfType<CheckBox>().Where(x => x.IsChecked == true);
            // var list = this.grid.Children.OfType<CheckBox>().Where(x => x.IsChecked == true);
            //var selectedItems = ValueCollection.Items.Cast<CheckBox>().Where(x => x.IsChecked == true).Select(x => x.Content).ToList();
            //MessageBox.Show(string.Join("\n", selectedItems));

            //var w_PreviewWindow = new PreviewWindow(result);
            //w_PreviewWindow.Show();
            //Hide();
        }


    }
}
