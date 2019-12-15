using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Text;


namespace Console_practice
{
    interface BPMObserver{ void update(); }
    interface IBPMController { void increaseBPM(); void decreaseBPM(); void setBPM(int bpm);}
    interface IBPMModelInterface
    {
        void setBPM(int bpm); int getBPM();
        void registerBPMObserver(BPMObserver o); void notifyBPMObserver();
    }
    
    class BPMModel :IBPMModelInterface
    {
        int bpm=90;
        List<BPMObserver> bpmObservers = new List<BPMObserver>();

        public void setBPM(int bpm) { this.bpm = bpm; notifyBPMObserver(); }
        public int getBPM() { return this.bpm; }

        public void registerBPMObserver(BPMObserver o)
        { bpmObservers.Add(o); }

        public void notifyBPMObserver()
        { foreach (BPMObserver o in bpmObservers) { o.update(); } }
    }

    class DJView : BPMObserver
    {
        IBPMModelInterface model; IBPMController controller;
        string bpmLabel;

        public DJView(IBPMModelInterface model, IBPMController controller)
        { 
            this.model = model; this.controller = controller;
            model.registerBPMObserver(this);
        }

        public void update() 
        {
            bpmLabel = "current BPM: " + model.getBPM();
            Console.WriteLine(bpmLabel);
        }

        /*
         * We will have some methods here attached to buttons
         * which will increase, decrease, and set BPM .  Inside these
         * methods, we will call controller.increaseBPM and
         * controller.decreaseBPM and controller.setBPM
         */
    }    
    
    class BPMController : IBPMController 
    {
        IBPMModelInterface model; DJView view;
        public BPMController(IBPMModelInterface model) 
        {
            this.model = model; view = new DJView(model, this);
        }
        
        public void increaseBPM() { model.setBPM(model.getBPM()+1); }
        public void decreaseBPM() { model.setBPM(model.getBPM() - 1); }
        public void setBPM(int bpm) { model.setBPM(bpm); }

    }

    class Program
    {
        static void Main(string[] args)
        {
            IBPMModelInterface model = new BPMModel();
            IBPMController controller = new BPMController(model);
            controller.increaseBPM();

            string z = Console.ReadLine();
        } //Main

        

    }//Program

} //namespace Console_practice