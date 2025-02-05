using jsquare.BL;
using System.Data;
using System.Windows;
using jsquare.Model;

namespace jsquare
{
    /// <summary>
    /// Interaction logic for AdminDashboard.xaml
    /// </summary>
    public partial class AdminDashboard : Window
    {
        public AdminDashboard()
        {
            InitializeComponent();
            string conn = "Integrated Security=SSPI; Persist Security Info=False; Initial Catalog=jsquare; Data Source=NITHYA\\SQLEXPRESS; Encrypt=false";
            SqlConnection sqlconn = new SqlConnection(conn);
            sqlconn.Open();
            string query = "select * from StudentDetails";
            SqlCommand cmd = new SqlCommand(query, sqlconn);
            SqlDataAdapter oda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            oda.Fill(ds);

            lststudent.ItemsSource = ds.Tables[0].DefaultView;
            sqlconn.Close();

            //AdminDash adminDash = new AdminDash();
            //string query = "select * from StudentDetails";

            //List<AdminDashbo> list = adminDash.getCheckinData(SQLquery);

            //lststudent.ItemsSource = list;




        }

        private void btnlogin_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnsearch_Click(object sender, RoutedEventArgs e)
        {
            if (txtregno.Text != "")
            {
                string conn = "Integrated Security=SSPI; Persist Security Info=False; Initial Catalog=jsquare; Data Source=NITHYA\\SQLEXPRESS; Encrypt=false";
                SqlConnection sqlconn = new SqlConnection(conn);
                sqlconn.Open();
                string query = "select * from StudentDetails where Regid=@Regid";
                SqlCommand cmd = new SqlCommand(query, sqlconn);
                cmd.Parameters.AddWithValue("@Regid", txtregno.Text);
                SqlDataAdapter oda = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                oda.Fill(ds);

                lststudent.ItemsSource = ds.Tables[0].DefaultView;
                sqlconn.Close();
            }
            else if(txtregno.Text == "ALL" || txtregno.Text == "" )
            {
               // MessageBox.Show("Give Reg Number");
                string conn = "Integrated Security=SSPI; Persist Security Info=False; Initial Catalog=jsquare; Data Source=NITHYA\\SQLEXPRESS; Encrypt=false";
                SqlConnection sqlconn = new SqlConnection(conn);
                sqlconn.Open();
                string query = "select * from StudentDetails";
                SqlCommand cmd = new SqlCommand(query, sqlconn);
                SqlDataAdapter oda = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                oda.Fill(ds);

                lststudent.ItemsSource = ds.Tables[0].DefaultView;
                sqlconn.Close();
            }

        }

        private void btnaddstudent_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnlogout_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainwin = new MainWindow();
            mainwin.ShowDialog();

        }

    }
}
