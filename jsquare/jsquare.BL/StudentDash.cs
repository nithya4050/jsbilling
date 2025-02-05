using jsquare.Model;
using jsquare.DA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace jsquare.BL
{
    public class StudentDash
    {
          private readonly SqlHelper _dBHelper;
          public StudentDash()
          {
            _dBHelper = new SqlHelper();
          }

        public StudentReg GetStudnet(string email, string password)
        {
            StudentReg student = new StudentReg();
            string query = "SELECT * FROM Registration WHERE EmailID =@email AND Password=@password";
            SqlParameter[] parameters =
               {
                new SqlParameter("@email", email),
                new SqlParameter("@password",password),

                };
            SqlDataReader reader = _dBHelper.SqlDataRead(query, parameters);
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    student.EmailID = reader.GetString(3);
                    student.Fullname = reader.GetString(2);
                    student.password = reader.GetString(4);
                    int id = (int)reader.GetDecimal(0);
                    student.id = id;
                }
            }
            return student;
        }

        public object DisableCheckin(StudentReg student)
        {
            string sqlQuery = "SELECT count(*) FROM STUDENTCHECKIN WHERE EmailId =@email AND Password=@password and cdate=@checkin";

            SqlParameter[] parameters =
                {
                new SqlParameter("@email", student.EmailID),
                new SqlParameter("@password", student.password),
                new SqlParameter("@Checkin", DateTime.Now.Date)
                };
            return _dBHelper.SqlExcuteScaller(sqlQuery, parameters);
        }

        public int UpdateStudent(StudentReg student)
        {
            string query = "update Registration set Fullname=@name,Email=@email,Password=@password where Regid=@userid";
            SqlParameter[] parameters ={
            new SqlParameter("@FullName", student.Fullname),
            new SqlParameter("@EmailId", student.EmailID),
            new SqlParameter("@Password", student.password),
            new SqlParameter("@userid", student.id)
            };

           return _dBHelper.sqlExcuteNonQuery(query, parameters);
        }

        public int Checkin(bool? project, bool? practice, bool? notes, int? userid)
        {
            int notesv = project == true ? 1 : 0;
            int demov = practice == true ? 1 : 0;
            int projectv = notes == true ? 1 : 0;
            string query = "INSERT INTO StudentActivity VALUES(@cdate,@project,@practice,@notes,@ID)";
            SqlParameter[] parameters ={
            new SqlParameter("@cdate", DateTime.Now.Date),
            new SqlParameter("@project", notesv),
            new SqlParameter("@practice", demov),
            new SqlParameter("@notes", projectv),
             new SqlParameter("@ID", projectv)
            };

            return _dBHelper.sqlExcuteNonQuery(query, parameters);
        }
    }
}
