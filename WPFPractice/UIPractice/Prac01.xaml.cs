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
using System.Windows.Navigation;
using System.Windows.Shapes;

using Stock.Data;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Prism.Commands;
using WPFUtils;
using System.ComponentModel;

namespace WPFPractice.Prac01
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {        

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new MainWindowVM();
        }
                
    }

    public class MainWindowVM : NPC, IValueConverter
    {
        public IStockDa SD { get; set; }

        public StockObject cs;
        public StockObject CurrentStock
        {
            get { return cs; }
            set { cs = value; OnPropertyChanged("CurrentStock"); }
        }

        public DelegateCommand<StockObject> ShowItemCommand { get; set; }

        public MainWindowVM()
        {
            InitObjects();
            InitCommands();
        }

        private void InitObjects()
        {
            UnityContainer container = new UnityContainer();

            bool icForStockDataValue = true;
            InjectionConstructor icForStockData = new InjectionConstructor(icForStockDataValue);
            container.RegisterType<IStockDa, StockDa>(/*new ContainerControlledLifetimeManager(),*/ icForStockData);
            
            SD = container.Resolve<IStockDa>();            
        }

        private void InitCommands()
        {
            ShowItemCommand = new DelegateCommand<StockObject>(new Action<StockObject>((s) =>
            {
                MessageBox.Show(s.Cusip);
            }));
        }

        #region converter
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            int val = 0;
            if (int.TryParse(value.ToString(), out val))
            {
                return val > 120;
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
        #endregion
    }
}
