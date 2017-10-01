using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace HQWebApi.Helpers
{
    public class SQLHelper
    {
        private SqlConnection mConnection;
        private SqlCommand mCommand;
        private SqlDataAdapter mDataAdapter = new SqlDataAdapter();

        public const string CONNECTION_STRING_KEY = "HQConnectionString";

        public SQLHelper()
        {
            mConnection = new SqlConnection(ConnectionString);
            mCommand = mConnection.CreateCommand();
        }

        public static string ConnectionString => ConfigurationManager.ConnectionStrings[CONNECTION_STRING_KEY].ConnectionString;
        
        public SqlConnection GetSqlConnection => mConnection;

        public SqlCommand SqlCommand => mCommand;

        public DataSet GetDataSet()
        {
            DataSet ds = null;
            try
            {
                mDataAdapter.SelectCommand = mCommand;
                ds = new DataSet();

                mConnection.Open();
                mDataAdapter.Fill(ds);
                mConnection.Close();
            }
            finally
            {
                mConnection.Close();
            }

            return ds;
        }

        public object ExecuteScalar()
        {
            object obj = null;
            try
            {
                mConnection.Open();
                obj = mCommand.ExecuteScalar();
                mConnection.Close();
            }
            finally
            {
                mConnection.Close();
            }

            return obj;
        }

        public int ExecuteNonQuery()
        {
            int rows = 0;
            try
            {
                mConnection.Open();
                rows = mCommand.ExecuteNonQuery();
                mConnection.Close();
            }
            finally
            {
                mConnection.Close();
            }

            return rows;
        }
    }
}