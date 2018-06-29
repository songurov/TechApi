using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace TechApi.Data
{
    public class SqlWrapper
    {
        private readonly SqlConnection _SQL_CONNECTION2 = new SqlConnection();
        public DataTable DATA_TABLE = new DataTable();

        public SqlWrapper()
        {
            _SQL_CONNECTION2.ConnectionString = ConfigurationManager.ConnectionStrings["connectServer"].ConnectionString;
        }

        public void Command(string command, IList<ItemSqlParams> param)
        {
            try
            {
                _SQL_CONNECTION2.Open();
                var dataAdapter = new SqlDataAdapter(command, _SQL_CONNECTION2);
                AddParamas(param, dataAdapter);
                dataAdapter.Fill(DATA_TABLE);
            }
            finally
            {
                _SQL_CONNECTION2.Close();
            }
        }

        private static void AddParamas(IEnumerable<ItemSqlParams> param, SqlDataAdapter dataAdapter)
        {
            foreach (var item in param)
                dataAdapter.SelectCommand.Parameters.AddWithValue("@" + item.Name, item.Value);
        }
    }
}