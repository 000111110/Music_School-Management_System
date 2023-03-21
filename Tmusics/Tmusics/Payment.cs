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
    public partial class Payment : Form
    {
        public Payment()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            home hom = new home();
            hom.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-39MKE60\\MSSQLSERVER01;Initial Catalog=Tmusics;Integrated Security=True");
            conn.Open();
            SqlCommand cmd = new SqlCommand("insert into payment values(@paymentid,@studentid,@admissionid,@Fees,@Month,@date)", conn);
            cmd.Parameters.AddWithValue("@paymentid", int.Parse(textBox1.Text));
            cmd.Parameters.AddWithValue("@studentid", textBox2.Text);
            cmd.Parameters.AddWithValue("@admissionid", textBox3.Text);
            cmd.Parameters.AddWithValue("@Fees", textBox4.Text);
            cmd.Parameters.AddWithValue("@Month", textBox5.Text);
            cmd.Parameters.AddWithValue("@date", DateTime.Parse(dateTimePicker2.Text));
           
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Payment Successfully Added");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-39MKE60\\MSSQLSERVER01;Initial Catalog=Tmusics;Integrated Security=True");
            conn.Open();
            SqlCommand cmd = new SqlCommand("update payment set studentid=@studentid,admissionid=@admissionid,Fees=@Fees,Month=@Month,date=@date where paymentid=@paymentid", conn);
            cmd.Parameters.AddWithValue("@paymentid", int.Parse(textBox1.Text));
            cmd.Parameters.AddWithValue("@studentid", textBox2.Text);
            cmd.Parameters.AddWithValue("@admissionid", textBox3.Text);
            cmd.Parameters.AddWithValue("@Fees", textBox4.Text);
            cmd.Parameters.AddWithValue("@Month", textBox5.Text);
            cmd.Parameters.AddWithValue("@date", DateTime.Parse(dateTimePicker2.Text));
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Payment Successfully Updated");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-39MKE60\\MSSQLSERVER01;Initial Catalog=Tmusics;Integrated Security=True");
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from payment", conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            dataGridView1.DataSource = dt;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-39MKE60\\MSSQLSERVER01;Initial Catalog=Tmusics;Integrated Security=True");
            conn.Open();
            SqlCommand cmd = new SqlCommand("delete payment where paymentid=@paymentid", conn);
            cmd.Parameters.AddWithValue("@paymentid", int.Parse(textBox1.Text));
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Payment Details Deleteted Successfully");
        }
    }
}
