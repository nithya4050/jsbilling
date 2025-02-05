using jsquare.DA;
using jsquare.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace jsquare.BL
{
    public class AdminDash
    {
        private readonly SqlHelper _dBHelper;
        public AdminDash()
        {
            _dBHelper = new SqlHelper();
        }
        //public List<AdminDashbo> getCheckinData(string query)
        //{
        //    string SQLquery = "SELECT * FROM StudentDetails";
        //    DataSet dataSet = new DataSet();
        //    dataSet = _dBHelper.SQLDataset(query);
        //    var JSONString = JsonConvert.SerializeObject(dataSet.Tables[0]);
        //    List<AdminDashbo> list = JsonConvert.DeserializeObject<List<AdminDashbo>>(JSONString);
        //    return list;
        //}
    }
}
