using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFPractice.SmartGrid
{
    public class SmartGridExampleViewModel
    {
        public SmartGridExampleViewModel()
        {
            //this.Rows = new ObservableCollection<Employee>() { new Employee("alan", 1), new Employee("Sybil", 2) };
        }

        public ObservableCollection<RowViewModel> Rows { get; set; }
    }
}
