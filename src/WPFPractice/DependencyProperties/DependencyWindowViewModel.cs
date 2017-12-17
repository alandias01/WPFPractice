using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFPractice.DependencyProperties
{
    public class DependencyWindowViewModel
    {
        public DependencyWindowViewModel()
        {
            DataList = Employee.Load();
        }

        public ObservableCollection<Employee> DataList { get; set; }

        public void LoadCustomers()
        {

        }

        private object _si;
        public object SI
        {
            get
            {
                return _si;
            }
            set
            {
                this._si = value;
            }
        }
    }    
}
