using KFCapi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ToolBox.DesignPatterns.Repository;

namespace KFCapi.Repositories
{
    public interface IBuyerService : IDataService<Buyer, int>
    {
        Buyer Get(string name);
        
    }
}