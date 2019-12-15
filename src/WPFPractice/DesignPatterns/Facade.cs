using System; using System.Collections; using System.Collections.Generic;
using System.Collections.ObjectModel; using System.Collections.Specialized;
using System.Text;


namespace Console_practice
{
    //Facade just consolidates everything into one call to simplify things

    public class amplifier { public void on() { Console.WriteLine("amp on"); } }    
    public class CdPlayer { public void on() { Console.WriteLine("cd player on"); } }
    public class DvdPlayer { public void play(string movie) 
    { Console.WriteLine("Watching "+movie); } }

    public class HomeTheaterFacade
    {
        amplifier amp; DvdPlayer dvd; CdPlayer cd;
        
        public HomeTheaterFacade(amplifier amp, DvdPlayer dvd, CdPlayer cd)
        { this.amp = amp; this.dvd = dvd; this.cd = cd; }

        public void watchMovie(string movie)
        { amp.on(); cd.on(); dvd.play(movie); }    
    }


    class Program
    {

        static void Main(string[] args)
        {
            amplifier amp=new amplifier(); 
            DvdPlayer dvd =new DvdPlayer(); 
            CdPlayer cd=new CdPlayer();
            HomeTheaterFacade htf = new HomeTheaterFacade(amp, dvd, cd);
            htf.watchMovie("The Ring");


            string z = Console.ReadLine();
        } //Main

    }//Program

} //namespace Console_practice