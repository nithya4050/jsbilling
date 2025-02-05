using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jsquare.Model
{
    public class AdminDashbo
    {

        public int id { get; set; }
        public string FullName { get; set; }
        public int EmailID { get; set; }
        public DateOnly CheckinDate { get; set; }
        public int Project { get; set; }
        public int Notes { get; set; }

        public int practice { get; set; }
    }
}
