using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolBox.DbContact
{
    public class Command
    {
        private string _CommandText;
        private bool _IsStoredProcedure;
        private IDictionary<string, object> _Parameters;
        private IDictionary<string, bool> _Outputs;
        
        public Command(string CommandText, IDictionary<string, object> Parameters, bool IsStoredProcedure = false)
        {
            this.IsStoredProcedure = IsStoredProcedure;
            this.CommandText = CommandText;
            this.Parameters = new Dictionary<string, object>();
            this.Outputs = new Dictionary<string, bool>();
            if (Parameters != null)
            {
                foreach (KeyValuePair<string, object> parameter in Parameters)
                {
                    this.Parameters.Add(parameter);
                }
            }
        }

        public Command(string CommandText, bool IsStoredProcedure = false) : this(CommandText, null, IsStoredProcedure) { }

        internal bool IsStoredProcedure
        {
            get
            {
                return _IsStoredProcedure;
            }

            set
            {
                _IsStoredProcedure = value;
            }
        }

        internal string CommandText
        {
            get
            {
                return _CommandText;
            }

            set
            {
                _CommandText = value;
            }
        }

        internal IDictionary<string, object> Parameters
        {
            get
            {
                return _Parameters;
            }

            private set
            {
                _Parameters = value;
            }
        }

        internal IDictionary<string, bool> Outputs
        {
            get
            {
                return _Outputs;
            }

            private set
            {
                _Outputs = value;
            }
        }

        public void AddParameter(string ParameterName, object Value)
        {
            Parameters.Add(ParameterName, Value);
            Outputs.Add(ParameterName, false);
        }
        public void AddParameter(string ParameterName, object Value, bool output)
        {
            AddParameter(ParameterName, Value);
            Outputs.Add(ParameterName, output);
        }
    }
}
