using KFCapi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ToolBox.DesignPatterns.Repository;
using KFCapi.Services;

namespace KFCapi.Repositories
{
    public interface IInstalledEquipmentService : IDataService<InstalledEquipment, int>
    {
        IEnumerable<InstalledEquipment> GetByIdVoiture(int key);
    }
}