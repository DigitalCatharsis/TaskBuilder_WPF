using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TaskBuilder_WPF.Classes
{
    public class SubcategoryContentModel //:INotifyPropertyChanged
    {
        public string Content { get; set; }
        public bool IsSelected { get; set; }
    }
}
