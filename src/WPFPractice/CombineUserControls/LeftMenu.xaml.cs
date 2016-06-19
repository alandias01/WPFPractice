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

namespace WPFPractice.CombineUserControls
{
    /// <summary>
    /// Interaction logic for LeftMenu.xaml
    /// </summary>
    public partial class LeftMenu : UserControl
    {
        Window _w;
        StackPanel _tr;
        StackPanel _br;
        public LeftMenu(Window W, StackPanel TR, StackPanel BR)
        {
            InitializeComponent();
            _w = W;
            _tr = TR;
            _br = BR;
        }

        private void label1_MouseEnter(object sender, MouseEventArgs e)
        {
            if (_tr.Children.Count == 0)
            {
                _tr.Children.Add(new TopRight());
            }
        }

        private void label2_MouseEnter(object sender, MouseEventArgs e)
        {
            if (_tr.Children.Count > 0)
            {
                _tr.Children.Clear();
            }
        }
    }
}
