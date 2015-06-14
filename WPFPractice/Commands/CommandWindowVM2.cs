using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Stock.Data;
using WPFUtils;


namespace WPFPractice.Commands
{
    class CommandWindowVM2
    {        
        private Command _sdc;
        public Command SDC
        {
            get
            {
                return _sdc ?? (_sdc = new Command(ShowCustomerDetails, IsCustomerSelected));
            }
        }

        private string _scID;
        public string SCID
        { 
            get { return _scID; }
            set
            {
                _scID = value;
                SDC.RaiseCanExecuteChanged();
            }
        }

        public void ShowCustomerDetails(object o)
        {
            if (!IsCustomerSelected(o))
            {
                throw new InvalidOperationException("Unable to show customer because no customer is selected.");
            }
            
            /*
            CustomerDetailsViewModel customerDetailsViewModel= GetCustomerDetailsTool(SelectedCustomerID);
            if (customerDetailsViewModel == null)
            {
                customerDetailsViewModel = new CustomerDetailsViewModel(_dataProvider, SelectedCustomerID);
                Tools.Add(customerDetailsViewModel);
            }

            SetCurrentTool(customerDetailsViewModel);
            */
        }
        
        //Show details link will be disabled until we select a customer
        public bool IsCustomerSelected(object o)
        {
            return !string.IsNullOrEmpty(SCID);
        }

    }


    
}
