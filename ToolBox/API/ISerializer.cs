using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ToolBox.API
{
    public interface ISerializer
    {
        StringContent SerializeObject(object Object);
        T DeserializeToObject<T>(string SerializedObject)
            where T : class, new();
    }
}
