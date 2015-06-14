using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Collections.ObjectModel;

using SL.Data;
using System.ComponentModel;

namespace WPFPractice.Controls
{
    /// <summary>
    /// Interaction logic for ListBoxStuff.xaml
    /// </summary>
    public partial class ListBoxStuff : Window//,INotifyPropertyChanged
    {
        SLEntities SE = new SLEntities();
        public List<IncomingDeliveryOrder> IDOList { get; set; }

        int _idoid;
        public int IDOID
        { 
            get { return _idoid; } 
            set 
            { 
                _idoid = value;                
            } 
        }

        public ListBoxStuff()
        {          
            InitializeComponent();
            this.DataContext = this;
            IDOList = new List<IncomingDeliveryOrder>();
            IDOList = SE.IncomingDeliveryOrders.ToList();
            
        }
        
    }
}
