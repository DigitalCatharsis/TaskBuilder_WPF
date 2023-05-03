using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskBuilder_WPF.Classes
{
    public class CategoryModel
    {
        //expandersInfo
        public string CategoryName { get; set; }
        public ObservableCollection<SubcategoryContentModel> CheckBoxContent { get; set; }
    }
}
