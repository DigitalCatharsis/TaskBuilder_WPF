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

namespace TaskBuilder_WPF
{
    /// <summary>
    /// Interaction logic for StartWindow.xaml
    /// </summary>
    public partial class StartWindow : Window
    {
        public StartWindow()
        {
            InitializeComponent();

        }

        private void CheckFile()
        {
            //Если не кнопка имени файла не нажата и разделитель не выбран, всплывает сообщение
            //Если такого файла не существует, всплывает сообщение
            //Проверка, что файл не занят
            
        }

        private void TryReadFile()
        {
            //Попытка считать файл
            //Путь указан не верно, либо неверный разделитель.
        }

        private void Button_Click_Continue(object sender, RoutedEventArgs e)
        {
            CheckFile();
            TryReadFile();
            //Открыть окно Selection
        }

        private void TB_InputFilePath_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
