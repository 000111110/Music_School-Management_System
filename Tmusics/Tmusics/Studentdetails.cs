using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tmusics
{
    public partial class Studentdetails : Form
    {
        public Studentdetails()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-39MKE60\\MSSQLSERVER01;Initial Catalog=Tmusics;Integrated Security=True");
            conn.Open();
            SqlCommand cmd = new SqlCommand("insert into studenttable values(@studentid,@fullname,@dob,@address,@program,@classtype,@registerdate)", conn);
            cmd.Parameters.AddWithValue("@studentid", textBox1.Text);
            cmd.Parameters.AddWithValue("@fullname", textBox2.Text);
            cmd.Parameters.AddWithValue("@dob", DateTime.Parse(dateTimePicker1.Text));
            cmd.Parameters.AddWithValue("address", textBox3.Text);
            cmd.Parameters.AddWithValue("program",comboBox1.Text);
            cmd.Parameters.AddWithValue("classtype", comboBox2.Text);
            cmd.Parameters.AddWithValue("registerdate", DateTime.Parse(dateTimePicker2.Text));
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Successfully Added");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-39MKE60\\MSSQLSERVER01;Initial Catalog=Tmusics;Integrated Security=True");
            conn.Open();
            SqlCommand cmd = new SqlCommand("update studenttable set registerdate=@registerdate, classtype=@classtype, program=@program, dob=@dob, fullname=@fullname where studentid=@studentid", conn);
            cmd.Parameters.AddWithValue("@studentid", textBox1.Text);
            cmd.Parameters.AddWithValue("@fullname", textBox2.Text);
            cmd.Parameters.AddWithValue("@dob", DateTime.Parse(dateTimePicker1.Text));
            cmd.Parameters.AddWithValue("address", textBox3.Text);
            cmd.Parameters.AddWithValue("program", comboBox1.Text);
            cmd.Parameters.AddWithValue("classtype", comboBox2.Text);
            cmd.Parameters.AddWithValue("registerdate", DateTime.Parse(dateTimePicker2.Text));
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Successfully Updated");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-39MKE60\\MSSQLSERVER01;Initial Catalog=Tmusics;Integrated Security=True");
            conn.Open();
            SqlCommand cmd = new SqlCommand("delete studenttable where studentid=@studentid", conn);
            cmd.Parameters.AddWithValue("@studentid", textBox1.Text);
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Successfully Deleteted");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-39MKE60\\MSSQLSERVER01;Initial Catalog=Tmusics;Integrated Security=True");
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from studenttable", conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            dataGridView1.DataSource = dt;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Class_Admission classad  = new Class_Admission ();
            classad.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            home hom = new home();
            hom.Show();
        }
    }
}
