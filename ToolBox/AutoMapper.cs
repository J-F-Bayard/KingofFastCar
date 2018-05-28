using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ToolBox
{
    public static class AutoMapper<TInput, TOutput>
    {
        public static TOutput AutoMap(TInput input)
        {
            TOutput output = System.Activator.CreateInstance<TOutput>();
            foreach (PropertyInfo pi in output.GetType().GetProperties())
            {
                var value = input.GetType().GetProperty(pi.Name)?.GetValue(input);
                if (value != null) pi.SetValue(output, value);
            }
            return output;
        }
    }
}
