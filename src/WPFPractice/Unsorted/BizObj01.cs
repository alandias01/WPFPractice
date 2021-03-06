﻿using System.ComponentModel;

namespace WPFPractice.Unsorted
{
    public class BizObj01
    {        
        public BizObj01()
        {            
        }
    }

    public interface IObjectStatusManagement
    {
        bool IsNew { get; }
        bool IsDirty { get; }
        bool IsValid { get; }        
    }

    public class MyObject : IObjectStatusManagement
    {
        private string _ticker;
        private int _qty;
        private int _price;

        public string Ticker { get { return _ticker; } set { _ticker = value; MarkDirty(); } }
        public int Qty { get { return _qty; } set { _qty = value; MarkDirty(); } }
        public int Price { get { return _price; } set { _price = value; MarkDirty(); } }

        private bool _isNew = true;
        private bool _isDirty = true;
        private bool _isValid = true;

        [Browsable(false)]
        public bool IsNew { get { return _isNew; } }

        [Browsable(false)]
        public bool IsDirty { get { return _isDirty; } }

        [Browsable(false)]
        public bool IsValid { get { return _isValid; } }

        public virtual void MarkOld()
        {
            _isNew = false;
            MarkClean();            
        }

        protected virtual void MarkNew()
        {
            _isNew = true;
            MarkDirty();
        }

        protected virtual void MarkClean()
        {
            _isDirty = false;
        }

        protected virtual void MarkDirty()
        {
            MarkDirty(false);
        }

        protected void MarkDirty(bool SuppressEvent)
        {
            _isDirty = true;
            if (!SuppressEvent) { /*OnUnknownPropertyChanged();*/ }
        }

        protected void SetProperty<T>(T NameProperty, T Value)
        {
            if (NameProperty is string) { string.IsNullOrEmpty(NameProperty as string); }
        }
    }
    
    /*
     * Constructor
     * takes in sqldatareader = MarkOld()
     * takes in new values = MarkNew()
     * 
     */
}
