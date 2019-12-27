using System;

namespace WPFPractice.Unsorted
{
    /* How to use Delegates with Events properly
     * We use a delegate keyword to create a delegate.
     * Then use a delegate to create a delegate object
     * We use the delegate object to point to methods with the same return type and signature as the delegate 
     * 
     * Delegates promote good separation of functionality     * 
     * Name of delegate and delegate object have syntax "EventNameDelegate" and EventName
     * Name of method that raises the event has syntax "onEventName"
     * When you add the word event before the delegate, the delegate instance can only be invoked in a method which 
     * resides in the class which raises it.  This improves security and eliminates the need to create public add methods
     * 
     * We own a factory and we bought 3 machines and they provide us with an API.  
     * Each API allows us the functionality to shut off their machine
     * We could pass in each Machine object into our controller and call the shutdown method but we want separation of logic
     * Controller class will have an event that points to the shutdown method of each machine 
     */

    public class Compressor { public void ShutOffCompressor() { Console.WriteLine("ShutOffCompressor"); } }
    public class Condenser { public void ShutOffCondenser() { Console.WriteLine("ShutOffCondenser"); } }
    public class Radiator { public void ShutOffRadiator() { Console.WriteLine("ShutOffRadiator"); } }
    
    public delegate void StopMachineDelegate();

    public class Controller
    {
        public event StopMachineDelegate StopMachine;
        public void onStopMachine()
        {
            StopMachineDelegate stopMachine=StopMachine;
            if (stopMachine != null) { stopMachine(); }
        }
    }

    public class EventHandling02
    {        
        public EventHandling02()
        {
            Controller c = new Controller();
            
            Compressor compressor = new Compressor();
            Condenser condenser = new Condenser();
            Radiator radiator = new Radiator();

            c.StopMachine += compressor.ShutOffCompressor;
            c.StopMachine += condenser.ShutOffCondenser;
            c.StopMachine += radiator.ShutOffRadiator;
            c.onStopMachine();

            /* Since the controller doesn't hold references to the objects but pnly the methods, we've decoupled
             * the controller from the machine objects.  This is good design             
             */
        }
    }
}
