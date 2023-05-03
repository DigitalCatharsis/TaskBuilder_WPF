using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskBuilder_WPF.Classes
{
    public class ExpandersInfo
    {
        public string CategoryName { get; set; }
        public ObservableCollection<string> CategoryContent { get; set; }
    }
}
