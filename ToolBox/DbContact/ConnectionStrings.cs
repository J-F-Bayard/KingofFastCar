using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolBox.DbContact
{
    public static class ConnectionStrings
    {
        public static string GetSqlConnectionString(string server, string database, string userID, string userPwd)
        {
            return @"Server=" + server + ";Database=" + database + ";User Id=" + userID + ";Password=" + userPwd;
        }
        public static string GetSqlConnectionInvariantName()
        {
            return "System.Data.SqlClient";
        }
        public static string GetSqlConnectionString(string server, string database)
        {
            return @"Server=" + server + ";Database=" + database + ";Trusted_Connection=True";
        }
        public static string GetMysqlConnectionString(string server, string database, string userName, string userPwd)
        {
            return @"Server=" + server + ";Database=" + database + ";Uid=" + userName + ";Pwd=" + userPwd + ";";
        }
        public static string GetMysqlConnectionString(string server, string database, string userName, string userPwd, int port)
        {
            return @"Server=" + server + ";Port=" + port + ";Database=" + database + ";Uid=" + userName + ";Pwd=" + userPwd + ";";
        }
    }
}
