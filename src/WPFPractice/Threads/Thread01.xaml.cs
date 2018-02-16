using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WPFPractice.Threads
{
    /// <summary>
    /// Interaction logic for Thread01.xaml
    /// </summary>
    public partial class Thread01 : Window
    {
        public Thread01()
        {
            InitializeComponent();
            RunTasks();
        }

        bool stop = false;

        private async void RunTasks()
        {
            lblDisplay.Content = "starting";


            for (int i = 0; i < 7; i++)
            {                
                await DelayTask();
                if (stop)
                {
                    break;
                }

                lblDisplay.Content = i.ToString();                
            }

            lblDisplay.Content = "Done";
        }

        private Task DelayTask() { return Task.Delay(1000); }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            stop = !stop;
        }
    }
}
