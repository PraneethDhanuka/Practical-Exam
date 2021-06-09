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
    public partial class Manager : Form
    {
        public Manager()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ACER\Desktop\productionmanagement\ProductionManagement\Database3.mdf;Integrated Security=True;");
        private void btnInsert_Click(object sender, EventArgs e)
        {
            conn.Open();

            String query = "INSERT INTO Employee(Employee_ID,Employee_Name,Email,Designation,Salary) VALUES ('" + textEmpid.Text + "','" + textEmp.Text + "','" + textEmail.Text + "','" + textDesignation.Text + "','" + textSalary.Text + "')";
            SqlDataAdapter sda = new SqlDataAdapter(query, conn);
            sda.SelectCommand.ExecuteNonQuery();
            conn.Close();

            MessageBox.Show("Record Insert Successfully...!!","Saved",MessageBoxButtons.OK,MessageBoxIcon.Information);
            ResetFormControls();
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            conn.Open();
            string query = "SELECT * FROM Employee";
            SqlDataAdapter sda = new SqlDataAdapter(query, conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            conn.Open();
            string query = "UPDATE Employee SET Employee_Name='" + textEmp.Text + "',Email='" + textEmail.Text + "',Designation='" + textDesignation.Text + "',Salary='" + textSalary.Text + "'WHERE Employee_ID='" + textEmpid.Text + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, conn);
            sda.SelectCommand.ExecuteNonQuery();
            conn.Close();

            MessageBox.Show("Update Data Sucessfully..!!", "UPDATED", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ResetFormControls();
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            textEmpid.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textEmp.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textEmail.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            textDesignation.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            textSalary.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            conn.Open();
            string query = "DELETE FROM Employee Where Employee_ID='"+ textEmpid.Text +"'";
            SqlDataAdapter sda = new SqlDataAdapter(query, conn);
            sda.SelectCommand.ExecuteNonQuery();
            conn.Close();

            MessageBox.Show("Record Delete Successfully..!!", "DELETED", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ResetFormControls();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetFormControls();

        }

        private void ResetFormControls()
        {
            textEmpid.Clear();
            textEmp.Clear();
            textEmail.Clear();
            textDesignation.Clear();
            textSalary.Clear();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
