using KFCapi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ToolBox.DesignPatterns.Repository;

namespace KFCapi.Repositories
{
    public interface IProviderService : IDataService<Provider, int>
    {
        Provider Get(string name);
    }
}