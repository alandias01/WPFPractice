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
using System.ComponentModel;
using System.Collections.ObjectModel;
using WPFUtils;
using System.Collections;

namespace WPFPractice.Commands
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new MainWindowViewModel();
        }
    }

    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Employee> EmpList { get; set; }

        public Command<Employee> ShowCurrentCommand { get; set; }
        public Command ButtonUpdateCommand { get; set; }
        public Command<IList> ShowSelectedItemsCommand1 { get; set; }
        public Command<IList> ShowSelectedItemsCommand2 { get; set; }

        public Employee currentItem;

        public Employee CurrentItem
        {
            get { return currentItem; }
            set
            {
                currentItem = value;
                ShowCurrentCommand.RaiseCanExecuteChanged();
                RaisePropertyChanged("CurrentItem");
                CommandManager.InvalidateRequerySuggested();
            }
        }

        public MainWindowViewModel()
        {
            EmpList = Employee.Load();
            ShowCurrentCommand = new Command<Employee>(add, CanAdd);
            ButtonUpdateCommand = new Command(update);
            ShowSelectedItemsCommand1 = new Command<IList>(ShowSelectedItems1);
            ShowSelectedItemsCommand2 = new Command<IList>(ShowSelectedItems2);
        }

        public void add(Employee e)
        {
            MessageBox.Show(e.Name);
        }

        public bool CanAdd(Employee e)
        {
            if (CurrentItem == null)
            {
                return false;
            }
            else
                //return e.Name.ToLower() == "alan";
                return CurrentItem.Name.ToLower() == "alan";
        }

        public void update(object o)
        {
            foreach (var item in EmpList)
            {
                item.Age += 1;
            }
        }



        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public void ShowSelectedItems1(IList s)
        {
 
        }

        public void ShowSelectedItems2(IList s)
        {

        }
    }
}
