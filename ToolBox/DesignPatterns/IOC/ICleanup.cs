using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolBox.DesignPatterns.IOC
{
    public interface ICleanup
    {
        event Action<Type> OnCleanup;
    }
}
