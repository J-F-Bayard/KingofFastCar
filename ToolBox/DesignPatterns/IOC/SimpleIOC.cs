using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolBox.Exceptions;

namespace ToolBox.DesignPatterns.IOC
{
    public class SimpleIOC : ISimpleIOC
    {
        private Dictionary<Type, object> _Instances;
        private Dictionary<Type, CtorInfo> _Infos;
        protected Dictionary<Type, object> Instances
        {
            get
            {
                return _Instances;
            }

            private set
            {
                _Instances = value;
            }
        }
        protected Dictionary<Type, CtorInfo> Infos
        {
            get
            {
                return _Infos;
            }

            private set
            {
                _Infos = value;
            }
        }

        public SimpleIOC()
        {
            Instances = new Dictionary<Type, object>();
            Infos = new Dictionary<Type, CtorInfo>();
        }       

        public TResource GetInstance<TResource>()
        {
            Type TTResource = typeof(TResource);
            if (Instances[TTResource] == null)
            {
                Instances[TTResource] = Activator.CreateInstance(Infos[TTResource].TResource, Infos[TTResource].Parameters);

                if (Instances[TTResource] is ICleanup)
                    ((ICleanup)Instances[TTResource]).OnCleanup += Clean;
            }

            return (TResource)Instances[TTResource];

            //return (TResource)(Instances[TTResource] ?? (Instances[TTResource] = Activator.CreateInstance(TTResource, Infos[TTResource].Parameters)));
        }        

        public void Register<TResource>()
        {
            Register<TResource>(null);
        }

        public void Register<TResource>(params object[] Parameters)
        {
            Type TTResource = typeof(TResource);
            Instances.Add(TTResource, null);
            Infos.Add(TTResource, new CtorInfo(TTResource, Parameters));
        }

        protected class CtorInfo
        {
            internal Type TResource { get; private set; }
            internal object[] Parameters { get; private set; }
            internal CtorInfo(Type TResource, object[] Parameters)
            {
                this.TResource = TResource;
                this.Parameters = Parameters;
            }
        }

        private void Clean(Type TResource)
        {
            ((ICleanup)Instances[TResource]).OnCleanup -= Clean;
            Instances[TResource] = null;
        }

        public void Register<TInterface, TResource>() 
            where TResource : TInterface
        {
            Register<TInterface, TResource>(null);
        }

        public void Register<TInterface, TResource>(params object[] Parameters) 
            where TResource : TInterface
        {
            Type TTInterface = typeof(TInterface);

            if (!TTInterface.IsInterface)
                throw new GenericArgumentException("TInterface must be an interface!");

            Instances.Add(TTInterface, null);
            Infos.Add(TTInterface, new CtorInfo(typeof(TResource), Parameters));
        }
    }
}
