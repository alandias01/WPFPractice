
using System.Collections.Generic;
using System.Dynamic;

namespace WPFPractice.SmartGrid
{
    public interface IRowViewModel
    {        
    }

    public class RowViewModel : DynamicObject, IRowViewModel
    {
        private Dictionary<string, object> values = new Dictionary<string, object>();
        
        public object this[string name]
        {
            get
            {
                return values[name];
            }
            set
            {
                values[name] = value;
            }
        }
    }
}
