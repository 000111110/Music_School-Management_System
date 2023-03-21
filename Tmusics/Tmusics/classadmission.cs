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
    public partial class Class_Admission : Form
    {
        public Class_Admission()
        {
            InitializeComponent();
        }

        private void Class_Admission_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

            this.Hide();
            Studentdetails Studet = new Studentdetails();
            Studet.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-39MKE60\\MSSQLSERVER01;Initial Catalog=Tmusics;Integrated Security=True");
            conn.Open();
            SqlCommand cmd = new SqlCommand("insert into admission values(@admissionid,@classid,@joindate,@studentid,@admissionfees)", conn);
            cmd.Parameters.AddWithValue("@admissionid", int.Parse(textBox4.Text));
            cmd.Parameters.AddWithValue("@classid", int.Parse(textBox1.Text));
            cmd.Parameters.AddWithValue("joindate", DateTime.Parse(dateTimePicker2.Text));
            cmd.Parameters.AddWithValue("studentid", int.Parse(textBox3.Text));
            cmd.Parameters.AddWithValue("admissionfees", textBox2.Text);
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Admission Completed");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-39MKE60\\MSSQLSERVER01;Initial Catalog=Tmusics;Integrated Security=True");
            conn.Open();
            SqlCommand cmd = new SqlCommand("update classadmission set admissionfees=@admissionfees,studentid=@studentid,joindate=@joindate,classid=@classid where admissionid=@admissionid ", conn);
            cmd.Parameters.AddWithValue("@admissionid", int.Parse(textBox4.Text));
            cmd.Parameters.AddWithValue("@classid", int.Parse(textBox1.Text));
            cmd.Parameters.AddWithValue("joindate", DateTime.Parse(dateTimePicker2.Text));
            cmd.Parameters.AddWithValue("studentid", int.Parse(textBox3.Text));
            cmd.Parameters.AddWithValue("admissionfees", textBox2.Text);
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Admission Updated");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-39MKE60\\MSSQLSERVER01;Initial Catalog=Tmusics;Integrated Security=True");
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from admission", conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            dataGridView1.DataSource = dt;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-39MKE60\\MSSQLSERVER01;Initial Catalog=Tmusics;Integrated Security=True");
            conn.Open();
            SqlCommand cmd = new SqlCommand("delete admission where admissionid=@admissionid", conn);
            cmd.Parameters.AddWithValue("@admissionid", int.Parse(textBox4.Text));
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Admission Deleteted");
        }
    }
}
