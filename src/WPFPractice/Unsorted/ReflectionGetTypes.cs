using System;
using System.Collections.Generic;
using System.Reflection;

namespace WPFPractice.Unsorted
{
    public class ReflectionGetTypes
    {
        public ReflectionGetTypes()
        {
            AutoFactory fac = new AutoFactory();
            IAuto car = fac.CreateInstance("bmw");
        }
    }

    public class AutoFactory
    {
        Dictionary<string, Type> autos;

        public AutoFactory()
        {
            LoadIAutoTypes();
        }


        public IAuto CreateInstance(string carName)
        {
            Type t = GetTypeToCreate(carName);
            if (t==null)
            {
                //return new NullAuto(); Null object pattern
                return null;
            }

            return Activator.CreateInstance(t) as IAuto;
        }

        private Type GetTypeToCreate(string carName)
        {
            foreach (var auto in autos)
            {
                if (auto.Key.Contains(carName))
                {
                    return autos[auto.Key];                    
                }
            }
            return null;
        }

        private void LoadIAutoTypes()
        {
            autos = new Dictionary<string, Type>();
            Type[] typesInThisAssembly = Assembly.GetExecutingAssembly().GetTypes();

            foreach (Type type in typesInThisAssembly)
            {
                if (type.GetInterface(typeof(IAuto).ToString()) != null)
                {
                    autos.Add(type.Name.ToLower(), type);
                }
            }
            
        }
    }

    public interface IAuto { }

    public class BMW : IAuto { }

    public class AUDI : IAuto { }
}