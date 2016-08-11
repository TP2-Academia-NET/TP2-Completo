using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;

namespace Data.Database
{
    public class Adapter
    {
        const string consKeyDefaultCnnString = "ConnStringLocal";

        public SqlConnection sqlConn { get; set; }

        protected SqlConnection OpenConnection()
        {
            string stringConnection = ConfigurationManager.ConnectionStrings[consKeyDefaultCnnString].ConnectionString;
            SqlConnection sqlConn = new SqlConnection(stringConnection);
            sqlConn.Open();
            return sqlConn;
        }

        protected void CloseConnection()
        {
            sqlConn.Close();
            sqlConn = null;
        }

        protected SqlDataReader ExecuteReader(String commandText)
        {
            throw new Exception("Metodo no implementado");
        }
    }
}
