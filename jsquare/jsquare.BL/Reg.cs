using jsquare.DA;
using Microsoft.Data.SqlClient;
using jsquare.Model;
using System.Data;

namespace jsquare.BL
{
    public class Reg
    {

        private readonly SqlHelper _dBHelper;
        public Reg()
        {
            _dBHelper = new SqlHelper();
        }


        public int Registration(StudentReg student)
        {
            string sqlQuery = $"INSERT INTO Registration(EmpType,FullName,EmailId,Password,cpassword,Qualification,Yearofpassedout,Experience,phoneno,Address,AddressProof,Dateofbirth,Age) VALUES(@EmpType,@FullName,@EmailId,@Password,@cpassword,@Qualification,@Yearofpassedout,@Experience,@phoneno,@Address,@AddressProof,@Dateofbirth,@Age)";
            SqlParameter[] parameters =
                {
                new SqlParameter("@EmpType", student.Employeetype),
                new SqlParameter("@FullName",student.Fullname),
                new SqlParameter("@EmailId",  student.EmailID),
                new SqlParameter("@Password", student.password),

                new SqlParameter("@cpassword", student.Cpassword),
                new SqlParameter("@Qualification", student.Qualification),
                new SqlParameter("@Yearofpassedout", student.Yearofpassedout),
                new SqlParameter("@Experience", student.Experiences),

                 new SqlParameter("@phoneno",student.Phoneno),
                new SqlParameter("@Address", student.Address),
                new SqlParameter("@AddressProof", student.Addressproof),
                new SqlParameter("@Dateofbirth", student.Dateofbirth),
                new SqlParameter("@Age", student.Age)

                };
            return _dBHelper.sqlExcuteNonQuery(sqlQuery, parameters);
        }

        public object LoginCheck(StudentReg student)
        {

            string sqlQuery = "select count(*) from Registration where EmailId = @EmailId and Password = @Password  and EmpType = @EmpType";
            SqlParameter[] parameters =
                {
                new SqlParameter("@EmpType", student.Employeetype),
                new SqlParameter("@EmailId",  student.EmailID),
                new SqlParameter("@Password", student.password)
                };
            return _dBHelper.SqlExcuteScaller(sqlQuery, parameters);
        }
    }
}