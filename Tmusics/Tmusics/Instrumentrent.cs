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
    public partial class Instrumentrent : Form
    {
        public Instrumentrent()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-39MKE60\\MSSQLSERVER01;Initial Catalog=Tmusics;Integrated Security=True");
            conn.Open();
            SqlCommand cmd = new SqlCommand("insert into instrumentrentdetails values(@instrumentid,@instrumenttype,@renteddate,@classid,@renterrole,@renterid)", conn);
            cmd.Parameters.AddWithValue("@instrumentid", int.Parse(textBox1.Text));
            cmd.Parameters.AddWithValue("@instrumenttype", textBox2.Text);
            cmd.Parameters.AddWithValue("renteddate", DateTime.Parse(dateTimePicker2.Text));
            cmd.Parameters.AddWithValue("classid", textBox4.Text);
            cmd.Parameters.AddWithValue("renterrole", comboBox1.Text);
            cmd.Parameters.AddWithValue("renterid", textBox3.Text);
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Rent Details Successfully Added");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-39MKE60\\MSSQLSERVER01;Initial Catalog=Tmusics;Integrated Security=True");
            conn.Open();
            SqlCommand cmd = new SqlCommand("update instrumentrentdetails set instrumentid=@instrumentid,instrumenttype=@instrumenttype,renteddate=@renteddate, instrumenttype=@instrumenttype where instrumentid=@instrumentid", conn);
            cmd.Parameters.AddWithValue("@instrumentid", int.Parse(textBox1.Text));
            cmd.Parameters.AddWithValue("@instrumenttype", textBox2.Text);
            cmd.Parameters.AddWithValue("renteddate", DateTime.Parse(dateTimePicker2.Text));
            cmd.Parameters.AddWithValue("classid", textBox4.Text);
            cmd.Parameters.AddWithValue("renterrole", comboBox1.Text);
            cmd.Parameters.AddWithValue("renterid", textBox3.Text);
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Instrument Details Successfully Updated");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-39MKE60\\MSSQLSERVER01;Initial Catalog=Tmusics;Integrated Security=True");
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from instrumentrentdetails", conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            dataGridView1.DataSource = dt;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-39MKE60\\MSSQLSERVER01;Initial Catalog=Tmusics;Integrated Security=True");
            conn.Open();
            SqlCommand cmd = new SqlCommand("delete instrumentrentdetails where renterid=@renterid", conn);
            cmd.Parameters.AddWithValue("@rentid", int.Parse(textBox1.Text));
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Successfully Deleteted ");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            home hom = new home();
            hom.Show();
        }
    }
}
