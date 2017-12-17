using Microsoft.Practices.Prism.Events;
using System;
using Microsoft.Practices.Unity;


namespace WPFPractice
{
    public class EventAggregation
    {
        IEventAggregator eventAggregator;

        public EventAggregation()
        {
            this.eventAggregator = UnityManager.container.Resolve<IEventAggregator>();
            //eventAggregator.GetEvent<DataEventArgs>().
        }
    }

    //class DataEventArgs : CompositeWpfEvent<string> { public string Name { get; set; } }
}
