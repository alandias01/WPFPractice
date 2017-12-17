using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using WPFPractice.DependencyProperties;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Prism.UnityExtensions;
using Microsoft.Practices.Prism.Events;

namespace WPFPractice
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        //universal list for different windows to communicate with
        List<string> DTCMessages = new List<string>();

        /*  This is what happens in the background
            Application app=new application()
            Windwo1 w=new window()
            app.run(w)
        */
        public App()
        {            
            IA1 a1 = new A1(new B1());
            //or
                        
            UnityManager.container.RegisterType<IB1, B1>();
            UnityManager.container.RegisterType<IA1, A1>();
            
            var a2 = UnityManager.container.Resolve<IA1>();

            UnityManager.container.RegisterType<IEventAggregator, EventAggregator>();
        }
        //Here you can handle application event
        //every event has a method that raises them "on + eventname"

        //You can replace the startupuri and put below
        //you can feed in arguments
        protected override void OnStartup(StartupEventArgs e)
        {
            //When overriding Application methods like OnStartUp() which raise its corresponding event, like startup event
            //its customary to call their method like base.OnStartUp first, then add your code            
            base.OnStartup(e);

            //This checks for arguments
            if (e.Args.Length > 0)
            {
                foreach (var v in e.Args)
                {

                }
            }
            
            new DependencyWindow().Show();
            
            //you can get access to the current application instance from anywhere
            //using application.current

            //Here we can shut down the application but this just returns Application.Run()
            //Or you can set in xaml  ShutdownMode="OnMainWindowClose"
            //If you handled the Application.exit event, that will run after Run()
            //Application.Current.Shutdown();

            //this gets you access to the main window but the main window is custom
            //Window w = Application.Current.MainWindow;

            //Its called public partial class MainWindow : Window so
            //to get access to everything in your mainwindow
            //MainWindow mw = (MainWindow)Application.Current.MainWindow;

            //If you want to communicate btwn windows
            //You can create a list here and access from other windows
            //((App)Application.Current).DTCMessages.Add("MSG01");
        }             
    }

    interface IB1 { }
    class B1 : IB1 { }

    interface IA1 { }
    class A1 : IA1
    {
        IB1 b1;
        public A1(IB1 b1) { this.b1 = b1; }
    }
    
    public class UnityManager
    {
        public static IUnityContainer container = new UnityContainer();
    }
}
