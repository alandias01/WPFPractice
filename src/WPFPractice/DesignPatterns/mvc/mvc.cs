using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Text;


namespace Console_practice
{

    class Program
    {
        static void Main(string[] args)
        {
            IBeatModelInterface model = new BeatModel();
            IControllerInterface controller = new BeatController(model);
            controller.increaeBPM(); //current BPM: 91


            string z = Console.ReadLine();
        } //Main

        

    }//Program

} //namespace Console_practice