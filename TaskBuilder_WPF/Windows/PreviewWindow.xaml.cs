using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
        private StringBuilder ResultProp { get; set; }
        public PreviewWindow(StringBuilder result)
        {
            InitializeComponent();
            ResultProp = result;
            textBlock.Text = ResultProp.ToString();

        }

        private void Button_Click_Start2(object sender, RoutedEventArgs e)
        {
            var w_StartWindow2 = new StartWindow();
            w_StartWindow2.Show();
            Hide();
        }

        private void Button_Click_OpenFile(object sender, RoutedEventArgs e)
        {
            CreateWriteOpenFile(ResultProp);
        }

        static void CreateWriteOpenFile(StringBuilder sb)
        {
            var date = ((DateTime.Now).ToString()).Replace(":", ".");
            var path = ($"{GetExeLocation()}\\Result {date}.doc");
            File.WriteAllText(path, sb.ToString());

            MessageBox.Show($"Файл записан по пути: {path}. \n Открываю файл..." );

            //open file
            Process.Start(new ProcessStartInfo(path) { UseShellExecute = true });
            //System.Diagnostics.Process.Start(path);
        }

        static string GetExeLocation()
        {
            var path = Environment.ProcessPath;
            path = Environment.ProcessPath.Substring(0, path.LastIndexOf('\\'));
            return path;
        }
    }
}
