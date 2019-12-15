using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Text;

namespace Console_practice
{
    public delegate void BallEventHandler(object sender, BallEventArgs e);

    public class Ball
    {
        public event BallEventHandler BallInPlay;

        public void onBallInPlay(BallEventArgs e)
        {
            BallEventHandler ballInPlay = BallInPlay;
            if (ballInPlay != null)
            {
                ballInPlay(this, e);
            }
        }
    }

    public class BallEventArgs : EventArgs
    {
        public int Speed { get; private set; }
        public int Distance { get; private set; }
        public BallEventArgs(int x, int y) { Speed = x; Distance = y; }
    }

    public class Pitcher
    {
        public Pitcher(Ball ball)
        {
            ball.BallInPlay += new BallEventHandler(ball_BallInPlay);
        }

        void ball_BallInPlay(object sender, EventArgs e)
        {
            BallEventArgs bea = e as BallEventArgs;
            Console.WriteLine("Pitches ball at" + bea.Speed + " and " + bea.Distance);
        }
    }



    class Program
    {
        static void Main(string[] args)
        {
            Ball ball = new Ball();
            Pitcher pitcher=new Pitcher(ball);

            BallEventArgs bea = new BallEventArgs(5, 7);
            ball.onBallInPlay(bea);
            string z = Console.ReadLine();
            
        } //Main       

    }//Program

} //namespace Console_practice