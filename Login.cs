using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ProductionManagement
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ACER\Desktop\productionmanagement\ProductionManagement\Database3.mdf;Integrated Security=True;");
            string query = "SELECT * FROM Login WHERE Username = '" + textBox1.Text.Trim() + "' AND Password = '" + textBox2.Text.Trim() + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, conn);
            DataTable dta = new DataTable();
            sda.Fill(dta);
            if (dta.Rows.Count == 1)
            {
                Manager mg = new Manager();
                this.Hide();
                mg.Show();
            }
            else
            {
                MessageBox.Show("Enter correct username and password please!");
            }
        }
    }
}