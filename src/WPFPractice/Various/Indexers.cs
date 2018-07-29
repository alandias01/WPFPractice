using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFPractice.Various
{
    public class Indexers
    {
    }

    public class BasicIndexer
    {
        private string[] values = new string[100];
                
        public string this[int number]
        {
            get
            {
                if (number > 0 && number < values.Length)
                {
                    return values[number];
                }
                return "Error";
            }
            set
            {
                if (number > 0 && number < values.Length)
                {
                    values[number] = value;
                }
            }
        }
    }

    public class DictionaryIndexer
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
