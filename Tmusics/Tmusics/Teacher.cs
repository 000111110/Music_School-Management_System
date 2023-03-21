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
    public partial class Teacher : Form
    {
        public Teacher()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-39MKE60\\MSSQLSERVER01;Initial Catalog=Tmusics;Integrated Security=True");
            conn.Open();
            SqlCommand cmd = new SqlCommand("insert into teacherdetails values(@teacherid,@fullname,@dob,@address,@program,@classtype,@registerdate,@phonenumber,@contractperiod)", conn);
            cmd.Parameters.AddWithValue("@teacherid", int.Parse(textBox1.Text));
            cmd.Parameters.AddWithValue("@fullname", textBox2.Text);
            cmd.Parameters.AddWithValue("@dob", DateTime.Parse(dateTimePicker1.Text));
            cmd.Parameters.AddWithValue("address", textBox3.Text);
            cmd.Parameters.AddWithValue("program", comboBox1.Text);
            cmd.Parameters.AddWithValue("classtype", comboBox2.Text);
            cmd.Parameters.AddWithValue("registerdate", DateTime.Parse(dateTimePicker2.Text));
            cmd.Parameters.AddWithValue("phonenumber", textBox4.Text);
            cmd.Parameters.AddWithValue("contractperiod", textBox5.Text);
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Teacher Details Successfully Added");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-39MKE60\\MSSQLSERVER01;Initial Catalog=Tmusics;Integrated Security=True");
            conn.Open();
            SqlCommand cmd = new SqlCommand("update teacherdetails set contractperiod=@contractperiod,phonenumber=@phonenumber, registerdate=@registerdate, classtype=@classtype, program=@program, dob=@dob, fullname=@fullname where teacherid=@teacherid", conn);
            cmd.Parameters.AddWithValue("@teacherid", int.Parse(textBox1.Text));
            cmd.Parameters.AddWithValue("@fullname", textBox2.Text);
            cmd.Parameters.AddWithValue("@dob", DateTime.Parse(dateTimePicker1.Text));
            cmd.Parameters.AddWithValue("address", textBox3.Text);
            cmd.Parameters.AddWithValue("program", comboBox1.Text);
            cmd.Parameters.AddWithValue("classtype", comboBox2.Text);
            cmd.Parameters.AddWithValue("registerdate", DateTime.Parse(dateTimePicker2.Text));
            cmd.Parameters.AddWithValue("phonenumber", textBox4.Text);
            cmd.Parameters.AddWithValue("contractperiod", textBox5.Text);
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Teacher Details Successfully Updated");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-39MKE60\\MSSQLSERVER01;Initial Catalog=Tmusics;Integrated Security=True");
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from teacherdetails", conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            dataGridView1.DataSource = dt;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-39MKE60\\MSSQLSERVER01;Initial Catalog=Tmusics;Integrated Security=True");
            conn.Open();
            SqlCommand cmd = new SqlCommand("delete teacherdetails where teacherid=@teacherid", conn);
            cmd.Parameters.AddWithValue("@teacherid", int.Parse(textBox1.Text));
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Successfully Deleteted");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            home hom = new home();
            hom.Show();
        }
    }
}
