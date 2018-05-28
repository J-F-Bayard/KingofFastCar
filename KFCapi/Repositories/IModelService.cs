using KFCapi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ToolBox.DesignPatterns.Repository;

namespace KFCapi.Repositories
{
    public interface IModelService : IDataService<Model, int>
    {
        Model GetByModelName(string name);
        Model GetByBrandName(string name);
    }
}