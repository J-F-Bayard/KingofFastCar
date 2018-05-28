using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolBox.DesignPatterns.IOC;

namespace ToolBox.DesignPatterns.Locator
{
    public abstract class LocatorBase
    {
        private ISimpleIOC _Container;

        protected ISimpleIOC Container
        {
            get
            {
                return _Container;
            }

            private set
            {
                _Container = value;
            }
        }

        public LocatorBase() : this(new SimpleIOC())
        {

        }

        public LocatorBase(ISimpleIOC Container)
        {
            this.Container = Container;
        }
    }
}
