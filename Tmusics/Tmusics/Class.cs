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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Tmusics
{
    public partial class Class : Form
    {
        public Class()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-39MKE60\\MSSQLSERVER01;Initial Catalog=Tmusics;Integrated Security=True");
            conn.Open();
            SqlCommand cmd = new SqlCommand("insert into classdetails values(@classid,@startdate,@classperiod,@teacherid)", conn);
            cmd.Parameters.AddWithValue("@classid", int.Parse(textBox1.Text));
            cmd.Parameters.AddWithValue("@startdate", DateTime.Parse(dateTimePicker2.Text));
            cmd.Parameters.AddWithValue("@classperiod", textBox4.Text);
            cmd.Parameters.AddWithValue("@teacherid", textBox3.Text);
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Class Details Successfully Added");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-39MKE60\\MSSQLSERVER01;Initial Catalog=Tmusics;Integrated Security=True");
            conn.Open();
            SqlCommand cmd = new SqlCommand("update classdetails set teacherid=@teacherid,classperiod=@classperiod,startdate=@startdate where classid=@classid", conn);
            cmd.Parameters.AddWithValue("@classid", int.Parse(textBox1.Text));
            cmd.Parameters.AddWithValue("@startdate", DateTime.Parse(dateTimePicker2.Text));
            cmd.Parameters.AddWithValue("@classperiod", textBox4.Text);
            cmd.Parameters.AddWithValue("@teacherid", textBox3.Text);
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Class Details Successfully Updated");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-39MKE60\\MSSQLSERVER01;Initial Catalog=Tmusics;Integrated Security=True");
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from classdetails", conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            dataGridView1.DataSource = dt;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-39MKE60\\MSSQLSERVER01;Initial Catalog=Tmusics;Integrated Security=True");
            conn.Open();
            SqlCommand cmd = new SqlCommand("delete classdetails where classid=@classid", conn);
            cmd.Parameters.AddWithValue("@classid", int.Parse(textBox1.Text));
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Class Record Deleteted Successfully");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            home hom = new home();
            hom.Show();
        }
    }
}
