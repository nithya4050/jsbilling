
using Microsoft.Data.SqlClient;

using System.Data;

namespace jsquare.DA
{

    public class SqlHelper
    {
        public readonly string ConnectionString;

        public SqlHelper()
        {
            ConnectionString = "Integrated Security = SSPI; Persist Security Info = False ; Initial Catalog = jsquare; Data Source = NITHYA\\SQLEXPRESS;Encrypt=False";

        }
        public SqlConnection GetConnection()
        {
            return new SqlConnection(ConnectionString);
        }

        public int Execute(string sqlquery)
        {
            SqlConnection sqlconn = new SqlConnection(ConnectionString);
            sqlconn.Open();
            SqlCommand  ocmd= new SqlCommand(sqlquery, sqlconn);
            int i = ocmd.ExecuteNonQuery();
            sqlconn.Close();
            return 1;
        }

        public int sqlExcuteNonQuery(string sqlquery, SqlParameter[] parameters)
        {
            int output = 0;

            using (SqlConnection sqlcon = GetConnection())
            {
                sqlcon.Open();
                using (SqlCommand sqlcmd = new SqlCommand(sqlquery, sqlcon))
                {
                    sqlcmd.Parameters.AddRange(parameters);
                    output = sqlcmd.ExecuteNonQuery();
                }
                sqlcon.Close();
            }
            return output;
        }

        public object SqlExcuteScaller(string sqlQuery, SqlParameter[] parameters = null)
        {
            object output;
            using (SqlConnection sqlConnection = GetConnection())
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection))
                {
                    if (parameters != null)
                    {
                        sqlCommand.Parameters.AddRange(parameters);
                    }
                    output = sqlCommand.ExecuteScalar();
                }
                sqlConnection.Close();
            }
            return output;
        }
        public SqlDataReader SqlDataRead(string sqlQuery, SqlParameter[] parameters = null)
        {
            SqlDataReader output;
            SqlConnection sqlConnection = GetConnection();
            sqlConnection.Open();
            using (SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection))
            {
                if (parameters != null)
                {
                    sqlCommand.Parameters.AddRange(parameters);
                }
                output = sqlCommand.ExecuteReader();
            }

            return output;
        }
        public DataSet SQLDataset(string sqlQuery, SqlParameter[] parameters = null)
        {
            DataSet output = new DataSet(); ;
            SqlConnection sqlConnection = GetConnection();
            sqlConnection.Open();
            using (SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection))
            {
                if (parameters != null)
                {
                    sqlCommand.Parameters.AddRange(parameters);
                }
                SqlDataAdapter oda = new SqlDataAdapter(sqlCommand);
                oda.Fill(output);
            }

            return output;
        }

    }
}
