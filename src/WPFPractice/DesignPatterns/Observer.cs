using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Data;

namespace Console_practice
{
    public interface Subject
    { 
        void registerObserver(Observer o); 
        void removeObserver(Observer o); 
        void notifyObservers(); 
    }

    public interface Observer
    { 
        void update(float temp, float humidity, float pressure); 
    }

    public interface DisplayElement
    { 
        void display(); 
    }

    public class WeatherData : Subject
    {
        private List<Observer> observers;
        private float temperature, humidity, pressure;

        public WeatherData() { observers = new List<Observer>(); }

        public void registerObserver(Observer o) { observers.Add(o); }

        public void removeObserver(Observer o) { observers.Remove(o); }

        public void notifyObservers()
        {
            for (int i = 0; i < observers.Count; i++)
                observers[i].update(temperature, humidity, pressure);
        }

        public void measurementsChanged() { notifyObservers(); }

        public void setMeasurements(float temperature, float humidity, float pressure)
        {
            this.temperature = temperature;
            this.humidity = humidity;
            this.pressure = pressure;
            measurementsChanged();
        }
    }

        public class CurrentConditionsDisplay : Observer, DisplayElement
        {
            private float temperature, humidity; 
            private Subject weatherData;

            public CurrentConditionsDisplay(Subject weatherData)
            {
                this.weatherData = weatherData;
                weatherData.registerObserver(this);
            }

            public void update(float temperature, float humidity, float pressure)
            {
                this.temperature = temperature;
                this.humidity = humidity; display();
            }

            public void display() { Console.WriteLine("Temp: " + temperature + "\nHumidity: " + humidity); }
        }
     
    class Program
    {
        static void Main(string[] args)
        {
            WeatherData weatherData = new WeatherData();
            CurrentConditionsDisplay currentDisplay = new CurrentConditionsDisplay(weatherData);
            weatherData.setMeasurements(80, 65, 30.4f);

            string z = Console.ReadLine();
        } //Main


    }//Program
    
} //namespace Console_practice