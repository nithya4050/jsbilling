using jsquare.Model;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;
using jsquare.BL;
using System.Xml.Linq;

namespace jsquare
{
    /// <summary>
    /// Interaction logic for StudentDashboard.xaml
    /// </summary>
    public partial class StudentDashboard : Window
    {
        object userid;
        public StudentDashboard(string eimailID, string password, string Emptype)
        {
            InitializeComponent();

            int? role = 0;
            if (Emptype == "Staff")
            {
                role = 1;
            }
            else if (Emptype == "Student")
            {
                role = 2;

            }
           // StudentReg student = new StudentReg();
            StudentDash studdash = new StudentDash();


            StudentReg student = studdash.GetStudnet(eimailID, password);
            txtEmail.Text = student.EmailID;
            txtFullname.Text = student.Fullname;
            txtpassword.Password = student.password;
            userid = student.id;

            StudentReg ostudent = new StudentReg();
            ostudent.EmailID = eimailID;
            ostudent.password = password;
            object value = studdash.DisableCheckin(ostudent);
            int count = (int)value;
            if (count > 0)
            {
                btncheckin.IsEnabled = false;
            }

           
        }

        private void btnsaveas_Click(object sender, RoutedEventArgs e)
        {
            StudentReg student = new StudentReg();
            StudentDash studdash = new StudentDash();
            student.Fullname = txtFullname.Text;
            student.EmailID = txtEmail.Text;
            student.password = txtpassword.Password;
            student.id = Convert.ToInt32(userid);
            studdash.UpdateStudent(student);
            MessageBox.Show("Update Successfully");
        }

        private void btncheckin_Click(object sender, RoutedEventArgs e)
        {
            StudentDash studentDash = new StudentDash();
            studentDash.Checkin(rdbnotesdone.IsChecked, rdbprojectDone.IsChecked, rdbpracticedone.IsChecked, Convert.ToInt16(userid));
            MessageBox.Show("Update Successfully");
        }
    }
}
