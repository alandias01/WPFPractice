using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Unity;

namespace WPFPractice
{
    public class IOC
    {
        public IOC()
        {
            //Type registration; returns a new instance when you call resolve
            UnityContainer _c1 = new UnityContainer();
            
            _c1.RegisterType<IFace, HisFace>();
            var f1a = _c1.Resolve<IFace>();

            f1a.val = 1;

            //f1b.val will not be 1 
            var f1b = _c1.Resolve<IFace>();



            //Instance registration returns the instance you registered and manages its lifetime
            UnityContainer _c2 = new UnityContainer();

            HerFace m = new HerFace();            
            m.val = 1;
                        
            _c2.RegisterInstance<IFace>(m);

            //both will have val=1;
            var f2a = _c2.Resolve<IFace>();            
            var f2b = _c2.Resolve<IFace>();
            
            //both will have the value 2
            f2a.val = 2;

            //You may want unity to manage lifetime.  This will create a singleton
            UnityContainer _c3 = new UnityContainer();

            _c3.RegisterType<IFace, HisFace>(new ContainerControlledLifetimeManager());

            var f3a = _c3.Resolve<IFace>();
            f3a.val = 1;

            var f3b = _c3.Resolve<IFace>();
            
            //Constructor injection.  This will set the value of IFace to HisFace
            Human _human = _c3.Resolve<Human>();

            
            //You may have other values in the construtor
            UnityContainer _c4 = new UnityContainer();
            int a = 2;
            InjectionConstructor ic = new InjectionConstructor(new HerFace(), a);
            _c4.RegisterType<Human2>(ic);

            //_human2 is HerFace and val=2
            Human2 _human2 = _c4.Resolve<Human2>();

        }
    }


    public interface IFace { int val { get; set; } }
    public class HisFace : IFace { public int val { get; set; } }
    public class HerFace : IFace { public int val { get; set; } }

    public class Human
    {
        public IFace _face;

        public Human(IFace face)
        {
            _face = face;
        }
    }

    public class Human2
    {
        public IFace _face;
        int _a;
        public Human2(IFace face, int a)
        {
            _face = face;
            _a = a;
        }
    }
}
