using KFCapi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using ToolBox.DesignPatterns.Repository;

namespace KFCapi.Repositories
{
    public interface ILoginService : IDataService<Models.Login, int>
    {
        Models.Login CheckLogin(string email, string password);
    }
}