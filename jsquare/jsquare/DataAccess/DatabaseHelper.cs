global using Microsoft.Data.SqlClient;
using System.Data;


namespace jsquare.DataAccess
{
    
    public class DatabaseHelper
    {

        public  readonly string Connectionstring;

        public DatabaseHelper()
        {
            Connectionstring = "Integrated Security=SSPI; Persist Security Info=False; Initial Catalog=jsquare; Data Source=NITHYA\\SQLEXPRESS; Encrypt=false";
        }


        public SqlConnection Getconnection()
        {
            return new SqlConnection(Connectionstring);
        }

        public int sqlExcuteNonQuery(string sqlquery, SqlParameter[] parameters)
        {
            int output = 0;

            using (SqlConnection sqlcon = Getconnection())
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
    }

}
