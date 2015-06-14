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
using Stock.Data;
using SL.Data;

namespace WPFPractice.UI
{
    /// <summary>
    /// Interaction logic for w03.xaml
    /// </summary>
    public partial class w03 : Window
    {
        SLEntities SLE = new SLEntities();
        public List<PositionView> PVList { get; set; }
        
        public w03()
        {
            InitializeComponent();
            this.DataContext=this;
            PVList = new List<PositionView>();
            PVList = SLE.PositionViews.Where(x => x.DateOfData == new DateTime(2013, 01, 01)).ToList();
            //new PositionView().LoanValue
            
        }
    }
}
