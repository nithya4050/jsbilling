using jsquare.Pages;
using Microsoft.Data.SqlClient;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using jsquare.BL;
using jsquare.Model;

namespace jsquare
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            // CultureInfo culture = new CultureInfo(Properties.Settings.Default.language);
            //CultureInfo culture = new CultureInfo("ta_IN");
            //Thread.CurrentThread.CurrentCulture = culture;
            InitializeComponent();
        }

        private void btnlogin_Click(object sender, RoutedEventArgs e)
        {
            if (cmbemployeetype.Text == "")
            {
                MessageBox.Show("Select employee type");
            }

            else if ((txtemail.Text == "") && (txtpassword.Password == ""))
            {
                MessageBox.Show("Check emailid and password");
            }
            else
            {
                string Emptype = cmbemployeetype.Text;
                int? role = 0;
                if (Emptype == "Staff")
                {
                    role = 1;
                }
                else if (Emptype == "Student")
                {
                    role = 2;

                }


                StudentReg student = new StudentReg();
                student.Employeetype = role;
                student.EmailID = txtemail.Text;
                student.password = txtpassword.Password;
                Reg oreg = new Reg();
                int i = (int)oreg.LoginCheck(student);

                //string conn = "Integrated Security=SSPI; Persist Security Info=False; Initial Catalog=jsquare; Data Source=NITHYA\\SQLEXPRESS; Encrypt=false";
                //SqlConnection sqlconn = new SqlConnection(conn);
                //sqlconn.Open();
                //string query = $"select count(*) from Registration where EmailId = '{txtemail.Text}' and Password = '{txtpassword.Password}' and Emptype = {role}";
                //SqlCommand sqlCommand = new SqlCommand(query, sqlconn);

                //int i = (int)sqlCommand.ExecuteScalar();
                if (i >= 1) // if(i == 1)
                {
                    if (role == 1)
                    {
                        AdminDashboard admin = new AdminDashboard();
                        admin.Show();
                        this.Close();
                    }
                    else
                    {
                        StudentDashboard student1 = new StudentDashboard(txtemail.Text, txtpassword.Password, cmbemployeetype.Text);
                        student1.Show();
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Give valid username and password");
                }
            }
        }

        private void clear()
        {
            cmbregemployeetype.SelectedIndex = -1;
            cmblanguage.SelectedIndex = -1;
            cmbqualification.SelectedIndex = -1;
            cmbyearofpassedout.SelectedIndex = -1;
            cmbemployeetype.SelectedIndex = -1;

            txtaddress.Text = "";
            txtaddressProf.Text = "";
            txtage.Text = "";
            txtdob.Text = "";
            txtemail.Text = "";

            txtexperience.Text = "";
            txtpassword.Password = "";
            txtphoneNo.Text = "";
            txtqualification.Text = "";
            txtRegconfirmpassword.Password = "";

            txtRegpassword.Password = "";
            txtRegFullname.Text = "";
            txtRegEmail.Text = "";
            
        }



        private void btnRegistration_Click(object sender, RoutedEventArgs e)
        {

            if ((cmbregemployeetype.Text == "") || (txtRegFullname.Text == "") || (txtRegEmail.Text == "") || (txtRegpassword.Password == "") || (txtRegconfirmpassword.Password == ""))
            {
                MessageBox.Show("Check Login Details in Registration");
            }

            else if ((cmbqualification.Text == "") || (cmbyearofpassedout.Text == "") || (txtexperience.Text == "") || (txtdob.Text == "") || (txtage.Text == ""))
            {
                MessageBox.Show("Check Professional/personal Details");
            }
            else if ((txtphoneNo.Text == "") || (txtaddress.Text == "") || (txtaddressProf.Text == ""))
            {
                MessageBox.Show("Check Contact Details");
            }
            else
            {

                ComboBoxItem cmb = (ComboBoxItem)cmbregemployeetype.SelectedItem;

                string Emptype = cmbregemployeetype.Text;
                int role = 0;
                if (Emptype == "Staff")
                {
                    role = 1;
                }
                else if (Emptype == "Student")
                {
                    role = 2;

                }

                DateTime dateofbirth = Convert.ToDateTime(txtdob.Text);
                

                
                StudentReg student = new StudentReg();
                student.Employeetype = role;
                student.Fullname = txtRegFullname.Text;
                
                student.EmailID = txtRegEmail.Text;
                student.password = txtRegpassword.Password;
                student.Cpassword = txtRegconfirmpassword.Password;
                student.Qualification = cmbqualification.Text;
                student.Yearofpassedout = cmbyearofpassedout.Text;
                student.Experiences = txtexperience.Text;
                student.Phoneno = txtphoneNo.Text;
                student.Address = txtaddress.Text;
                student.Addressproof = txtaddressProf.Text;
                student.Dateofbirth = txtdob.Text;
                student.Age = txtage.Text;

                 Reg oreg = new Reg();
                int i = oreg.Registration(student);

               
                if(i>=1)
                {
                    MessageBox.Show("save Successfuly");
                }
                else
                {
                    MessageBox.Show("Failed");

                }

                //string conn = "Integrated Security=SSPI; Persist Security Info=False; Initial Catalog=jsquare; Data Source=NITHYA\\SQLEXPRESS; Encrypt=false";
                //SqlConnection sqlconn = new SqlConnection(conn);
                //sqlconn.Open();
                //string query = $"Insert into Registration(EmpType,FullName,EmailId,Password,cpassword,Qualification,Yearofpassedout,Experience,skills,phoneno,Address,AddressProof,Dateofbirth,Age) values('{role}','{txtRegFullname.Text}','{txtRegEmail.Text}','{txtRegpassword.Password}','{txtRegconfirmpassword.Password}','{cmbqualification.Text}','{cmbyearofpassedout.Text}','{txtexperience.Text}',null,'{txtphoneNo.Text}','{txtaddress.Text}','{txtaddressProf.Text}','{dateofbirth}','{txtage.Text}')";
                //SqlCommand sqlcmd = new SqlCommand(query, sqlconn);
                //int i = sqlcmd.ExecuteNonQuery();
                //sqlconn.Close();
                MessageBox.Show("Save successfully");
                clear();

            }
        }

        private void btnone_Registration_Click(object sender, RoutedEventArgs e)
        {
         //   mainframe.Content = new Registration1();
            

        }

        private void btnTwo_Registration_Click(object sender, RoutedEventArgs e)
        {
            Registeration reg = new Registeration();
            int EmpType = 0;           
            string emplyetype = cmbemployeetype.Text;
            if(emplyetype == "staff")
            {
               EmpType = Convert.ToInt32(emplyetype);
            }
            else if(emplyetype == "student")
            {
                EmpType = Convert.ToInt32(emplyetype);
            }
            reg.Employeetype = EmpType;



           // reg.Fullname = 


            //mainframe.Content = new Registration2();

        }

        private void btnThree_Registration_Click(object sender, RoutedEventArgs e)
        {
           // mainframe.Content = new Registration3();

        }

        //private void txtdob_TextChanged(object sender, TextChangedEventArgs e)
        //{
           
        //        DateTime dateofbirth = Convert.ToDateTime(txtdob.Text);
        //        DateTime Age_calc = DateTime.Now.Date;

        //        int age = Age_calc.Year - dateofbirth.Year;
        //        txtage.Text = Convert.ToString(age);
            
        //}

        private void btnnext1_Click(object sender, RoutedEventArgs e)
        {
            if ((cmbregemployeetype.Text == "") || (txtRegFullname.Text == "") || (txtRegEmail.Text == "") || (txtRegpassword.Password == "") || (txtRegconfirmpassword.Password == ""))
            {
                MessageBox.Show("Check Login Details in Registration");
            }
            else
            {
                Regtabcontrol.SelectedIndex = 1;
            }
        }

        private void btnnext2_Click(object sender, RoutedEventArgs e)
        {
            if ((cmbqualification.Text == "") || (cmbyearofpassedout.Text == "") || (txtexperience.Text == "") || (txtdob.Text == "") || (txtage.Text == ""))
            {
                MessageBox.Show("Check Professional/personal Details");
            }
            else
            {
                Regtabcontrol.SelectedIndex = 2;
            }
        }
    }
}