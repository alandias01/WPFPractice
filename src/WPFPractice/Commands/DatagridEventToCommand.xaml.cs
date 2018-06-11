using System.Collections.ObjectModel;
using System.Windows;
using Stock.Data;
using WPFUtils;
using GalaSoft.MvvmLight.Command;
using System.Collections;

namespace WPFPractice.Commands
{
    /// <summary>
    /// Interaction logic for DatagridStyle.xaml
    /// </summary>
    public partial class DatagridEventToCommand : Window
    {
        public RelayCommand<IList> ShowItemsCommand { get; set; }
        public Command ShowItemsCommand2 { get; set; }
        public ObservableCollection<IStockObject> Pos { get; set; }


        public DatagridEventToCommand()
        {
            InitializeComponent();
            this.DataContext = this;
            Pos = new StockDa(false).Positions;
            ShowItemsCommand = new RelayCommand<IList>(
                (s) =>
                {
                    //MessageBox.Show("Test");
                    
                    string CusipStringList = "";
                    foreach (StockObject item in s)
                    {
                        CusipStringList += item.Cusip;
                    }

                    MessageBox.Show(CusipStringList);
                    
                },

                (s) => {
                    return true;
                }
                );

            ShowItemsCommand2 = new Command(
                (s) =>
                {
                    MessageBox.Show("Test2");

                });

            
        }
    }
}
