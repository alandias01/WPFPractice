using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Stock.Data;
using WPFUtils;
using GalaSoft.MvvmLight.Command;
using System.Collections;
using System.Windows.Documents;

namespace WPFPractice.controls
{
    /// <summary>
    /// Interaction logic for DatagridStyle.xaml
    /// </summary>
    public partial class DatagridEventToCommand : Window
    {
        public RelayCommand<IList> ShowItemsCommand { get; set; }
        public Command ShowItemsCommand2 { get; set; }
        public ObservableCollection<StockObject> Pos { get; set; }


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
