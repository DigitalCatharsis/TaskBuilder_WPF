﻿using System;
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
    /// Interaction logic for SelectionWindow2.xaml
    /// </summary>
    /// 

    public partial class SelectionWindow2 : Window
    {
        public Dictionary<string, Dictionary<string, string>> FileContent { get; init; }
        public SelectionWindow2(Dictionary<string, Dictionary<string, string>> fileContent)
        {
            InitializeComponent();
            FileContent = fileContent;
            TestBlock.Text = (FileContent["Salutation"]["1"]);
        }

        public SelectionWindow2()
        {
            InitializeComponent();
        }

        private void PreviewGenerator()
        {
            // Create the DockPanel
            DockPanel myDockPanel = new DockPanel();
            myDockPanel.LastChildFill = true;
            foreach (var category in FileContent)
            {
                var expander = new Expander();
            }
        }

    }
}
