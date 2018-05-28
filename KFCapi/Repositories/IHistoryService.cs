using KFCapi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ToolBox.DesignPatterns.Repository;

namespace KFCapi.Repositories
{
    public interface IHistoryService : IDataService<History, int>
    {
        History GetByCar(int id);
    }
}