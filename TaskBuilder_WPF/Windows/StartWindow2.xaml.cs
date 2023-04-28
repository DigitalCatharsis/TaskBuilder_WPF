using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
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
    /// Interaction logic for StartWindow2.xaml
    /// </summary>
    public partial class StartWindow2 : Window
    {
        public StartWindow2()
        {
            InitializeComponent();
        }

        private void Browse_Click(object sender, RoutedEventArgs e)
        {
            // Create OpenFileDialog
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();

            // Set filter for file extension and default file extension
            dlg.DefaultExt = ".csv";
            dlg.Filter = "Csv Files (.csv)|*.csv";

            var path = Environment.ProcessPath;
            path = Environment.ProcessPath.Substring(0, path.LastIndexOf('\\'));
            dlg.InitialDirectory = path;

            // Display OpenFileDialog by calling ShowDialog method
            Nullable<bool> result = dlg.ShowDialog();

            // Get the selected file name and display in a TextBox
            if (result == true)
            {
                // Open document
                string filename = dlg.FileName;
                TBOX_Filepath.Text = filename;
            }
        }

        private void Button_Click_Continue(object sender, RoutedEventArgs e)
        {
            var filepath = TBOX_Filepath.Text;
            FileInfo fileInfo;

            if (filepath != String.Empty)
            {
                fileInfo = new FileInfo(filepath);
            }
            else
            {
                MessageBox.Show("Укажите путь до файла.", "Путь до файла пуст", MessageBoxButton.OK, MessageBoxImage.Warning); return;
            }

            if (CheckFileExist(filepath) && !CheckFileLocked(fileInfo))
            {
                try
                {
                    var fileContent = ReadFile(filepath);
                    var w_SelectionWindow3 = new SelectionWindow3(fileContent);
                    w_SelectionWindow3.Show();
                    Hide();
                }
                catch (Exception ex) { MessageBox.Show("Невозможно считать файл. Скорее всего файл не соответсвует требованиям шаблона, либо разделитель выбран неверно", "Ошибка чтения файла", MessageBoxButton.OK, MessageBoxImage.Error); }
            }
            else
            {
                if (!CheckFileExist(filepath))
                {
                    MessageBox.Show("Файл не сущсвтует.", "Ошибка открытия файла", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else if (CheckFileLocked(fileInfo))
                {
                    MessageBox.Show("Файл в данный момент запущен другой программой. Требуется закрыть файл и попробовать еще раз.", "Файл запущен!", MessageBoxButton.OK, MessageBoxImage.Warning);
                }

            }
        }

        private bool CheckFileLocked(FileInfo file)
        {
            try
            {
                using (FileStream stream = file.Open(FileMode.Open, FileAccess.Read, FileShare.None))
                {
                    stream.Close();
                }
            }
            catch (IOException)
            {
                //the file is unavailable because it is:
                //still being written to
                //or being processed by another thread
                //or does not exist (has already been processed)
                return true;
            }

            //file is not locked
            return false;
        }

        private bool CheckFileExist(string filepath)
        {
            if (@File.Exists(filepath) && filepath != null)
            {
                return true;
            }
            return false;
        }

        private Dictionary<string, Dictionary<string, string>> ReadFile(string filepath)
        {
            var dP_DelContent = (DP_DelimeterPanel.Children.OfType<RadioButton>().FirstOrDefault(r => r.IsChecked.HasValue && r.IsChecked.Value)).Content;
            var delimeter = (dP_DelContent.ToString())[^1];
            var dataReader = new DatabaseReader(delimeter.ToString());
            var results = dataReader.ReadData(filepath);
            return results;
        }

        public record DelimeterInfo(string Text, char Delimeter)
        {
            public override string ToString() => Text;
        }

    }
}
