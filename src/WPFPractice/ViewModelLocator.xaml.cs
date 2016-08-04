using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace WPFPractice
{    
    public partial class ViewModelLocator : Window
    {
        public ViewModelLocator()
        {
            InitializeComponent();
        }
    }
    
    public interface IUIDataProvider
    {
        List<string> GetEquities();
        object GetEquity(string cusip);
    }

    public class UIDataProvidor : IUIDataProvider
    {
        public List<string> GetEquities() { return new List<string>() { "A", "B" }; }
        public object GetEquity(string cusip) { return null; }
    }

    public class ViewModel01
    {
        private readonly IUIDataProvider _dataProvider;

        public List<string> Equities { get; set; }

        public ViewModel01(IUIDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
            Equities = _dataProvider.GetEquities();
        }
    }

    public class MyVMLocator
    {
        //Repeat below for every new viewmodel you have
        private static ViewModel01 _viewModel01;
        public static ViewModel01 ViewModel01Static
        {
            get
            {
                if (DesignerProperties.GetIsInDesignMode(new DependencyObject()))
                {
                    return null;
                }

                if (_viewModel01 == null)
                {
                    _viewModel01 = new ViewModel01(new UIDataProvidor());
                }

                return _viewModel01;
            }
        }


    }

}
