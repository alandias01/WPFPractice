using System;
using System.ComponentModel;

namespace Stock.Data
{
    public interface IStockObject
    {
        string Name { get; set; }
        string Cusip { get; set; }
        string Symbol { get; set; }
        int Qty { get; set; }
        int Price { get; set; }
        decimal Rate { get; set; }        
    }

    public class StockObject : INotifyPropertyChanged, IStockObject
    {
        public StockObject()
        {
        }

        public StockObject(string s, int q, int p, decimal r)
        {            
            this.Symbol = s;
            this.Qty = q;
            this.Price = p;
            this.Rate = r;
        }

        public StockObject(string name, string cusip, string symbol, int quantity, int price, decimal rate)
        {
            this.Name = name;
            this.Cusip = cusip;
            this.Symbol = symbol;
            this.Qty = quantity;
            this.Price = price;
            this.Rate = rate;
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set 
            { 
                _name = value;
                OnPropertyChanged("Name");
            }
        }

        private string _cusip;
        public string Cusip
        {
            get { return _cusip; }
            set
            {
                _cusip = value;
                OnPropertyChanged("Cusip");
            }
        }

        private string _symbol;
        public string Symbol
        {
            get
            { return _symbol; }
            set
            {
                _symbol = value;
                OnPropertyChanged("Symbol");
            }
        }

        private int _qty;
        public int Qty
        {
            get
            { return _qty; }
            set
            {
                _qty = value;
                OnPropertyChanged("Qty");
            }
        }

        private int _price;
        public int Price
        {
            get
            { return _price; }
            set
            {
                _price = value;
                OnPropertyChanged("Price");
            }
        }

        private decimal _rate;
        public decimal Rate
        {
            get
            { return Math.Round(_rate, 3); }
            set
            {
                _rate = value;
                OnPropertyChanged("Rate");
            }
        }
                
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
