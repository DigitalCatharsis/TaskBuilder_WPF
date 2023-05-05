using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TaskBuilder_WPF
{
    /// <summary>
    /// Interaction logic for StartWindow2.xaml
    /// </summary>
    public partial class StartWindow : Window
    {
        public StartWindow()
        {
            InitializeComponent();
        }

        private void Browse_Click(object sender, RoutedEventArgs e)
        {
            // Create OpenFileDialog
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();

            // Set filter for file extension and default file extension
            dlg.DefaultExt = ".xlsx";
            dlg.Filter = "Excel Files (.xlsx)|*.xlsx";

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

            if (filepath != string.Empty)
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
                    var w_SelectionWindow3 = new SelectionWindow(fileContent);
                    w_SelectionWindow3.Show();
                    Hide();
                }
                catch (Exception ex) { MessageBox.Show("Невозможно считать файл. Скорее всего файл не соответсвует требованиям шаблона.", "Ошибка чтения файла", MessageBoxButton.OK, MessageBoxImage.Error); }

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

        private List<CategoryModel> ReadFile(string filepath)
        {
            var dataReader = new DatabaseReader3();
            var results = dataReader.ReadToListOf_CategoryModel(filepath);
            return results;
        }

        private void Button_Click_Manual(object sender, RoutedEventArgs e)
        {
            try
            {
                var path = ($"{GetExeLocation()}\\TaskBuilderManual.doc");
                //open file
                Process.Start(new ProcessStartInfo(path) { UseShellExecute = true });
            }
            catch (Exception ex) { MessageBox.Show("Не удалось найти файл с инструкцией 'TaskBuilderManual.doc' в корневой папке программы.", "Ошибка открытия файла", MessageBoxButton.OK, MessageBoxImage.Error); }

        }

        static string GetExeLocation()
        {
            var path = Environment.ProcessPath;
            path = Environment.ProcessPath.Substring(0, path.LastIndexOf('\\'));
            return path;
        }

    }
}
