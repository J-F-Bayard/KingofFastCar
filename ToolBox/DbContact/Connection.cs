using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolBox.DbContact
{
    public class Connection
    {
        private string _ConnectionString;
        private DbProviderFactory _Provider;

        private string ConnectionString
        {
            get
            {
                return _ConnectionString;
            }

            set
            {
                _ConnectionString = value;
            }
        }

        private DbProviderFactory Provider
        {
            get
            {
                return _Provider;
            }

            set
            {
                _Provider = value;
            }
        }

        public Connection(string ConnectionString, string ProviderInvariantName)
        {
            Provider = DbProviderFactories.GetFactory(ProviderInvariantName);
            this.ConnectionString = ConnectionString;
            using (DbConnection c = CreateConnection())
            {
                c.Open();
            }
        }

        public int ExecuteNonQuery(Command Command)
        {
            using (DbConnection c = CreateConnection())
            {
                using (DbCommand cmd = CreateCommand(Command, c))
                {
                    c.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
        }
        public object ExecuteScalar(Command Command)
        {
            using (DbConnection c = CreateConnection())
            {
                using (DbCommand cmd = CreateCommand(Command, c))
                {
                    c.Open();
                    object o = cmd.ExecuteScalar();
                    return (o is DBNull) ? null : o;
                }
            }
        }
        public IEnumerable<T> ExecuteReader<T>(Command Command, Func<IDataRecord, T> Mapper)
        {
            if (Mapper == null)
            {
                throw new ArgumentNullException(nameof(Mapper));
            }
            using (DbConnection c = CreateConnection())
            {
                using (DbCommand cmd = CreateCommand(Command, c))
                {
                    c.Open();
                    using (DbDataReader Reader = cmd.ExecuteReader())
                    {
                        while (Reader.Read())
                        {
                            yield return Mapper(Reader);
                        }
                    }
                }
            }
        }
        public DataTable GetDataTable(Command Command)
        {
            using (DbConnection c = CreateConnection())
            {
                using (DbCommand cmd = CreateCommand(Command, c))
                {

                    using (DbDataAdapter da = Provider.CreateDataAdapter())
                    {
                        da.SelectCommand = cmd;
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        return dt;
                    }
                }
            }
        }
        private DbCommand CreateCommand(Command Command, DbConnection Connection)
        {
            DbCommand cmd = Connection.CreateCommand();
            cmd.CommandText = Command.CommandText;
            if (Command.IsStoredProcedure) cmd.CommandType = CommandType.StoredProcedure;
            foreach (KeyValuePair<string, object> kvp in Command.Parameters)
            {
                DbParameter parameter = Provider.CreateParameter();
                parameter.ParameterName = kvp.Key;
                parameter.Value = kvp.Value ?? DBNull.Value;
                if(Command.Outputs[kvp.Key]) parameter.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(parameter);
            }
            return cmd;
        }
        private DbConnection CreateConnection()
        {
            DbConnection c = Provider.CreateConnection();
            c.ConnectionString = ConnectionString;
            return c;
        }
    }
}
