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
    public partial class Instruments : Form
    {
        public Instruments()
        {
            InitializeComponent();
        }

        private void Instruments_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-39MKE60\\MSSQLSERVER01;Initial Catalog=Tmusics;Integrated Security=True");
            conn.Open();
            SqlCommand cmd = new SqlCommand("insert into instruments values(@instrumentid,@instrumentname,@purchasedate,@phonenumber,@warrantyperiod)",conn);
            cmd.Parameters.AddWithValue("@instrumentid", int.Parse(textBox1.Text));
            cmd.Parameters.AddWithValue("@instrumentname", textBox2.Text);
            cmd.Parameters.AddWithValue("purchasedate", DateTime.Parse(dateTimePicker2.Text));
            cmd.Parameters.AddWithValue("phonenumber", textBox4.Text);
            cmd.Parameters.AddWithValue("warrantyperiod", textBox5.Text);
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Instrument Details Successfully Added");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-39MKE60\\MSSQLSERVER01;Initial Catalog=Tmusics;Integrated Security=True");
            conn.Open();
            SqlCommand cmd = new SqlCommand("update instruments set @warrantyperiod=@warrantyperiod,phonenumber=@phonenumber,purchasedate=@purchasedate, instrumentname=@instrumentname where instrumentid=@instrumentid", conn);
            cmd.Parameters.AddWithValue("@instrumentid", int.Parse(textBox1.Text));
            cmd.Parameters.AddWithValue("@instrumentname", textBox2.Text);
            cmd.Parameters.AddWithValue("purchasedate", DateTime.Parse(dateTimePicker2.Text));
            cmd.Parameters.AddWithValue("phonenumber", textBox4.Text);
            cmd.Parameters.AddWithValue("warrantyperiod", textBox5.Text);
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Instrument Details Successfully Updated");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-39MKE60\\MSSQLSERVER01;Initial Catalog=Tmusics;Integrated Security=True");
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from instruments", conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            dataGridView1.DataSource = dt;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-39MKE60\\MSSQLSERVER01;Initial Catalog=Tmusics;Integrated Security=True");
            conn.Open();
            SqlCommand cmd = new SqlCommand("delete instruments where instrumentid=@instrumentid", conn);
            cmd.Parameters.AddWithValue("@instrumentid", int.Parse(textBox1.Text));
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Instrument Deleteted Successfully");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            home hom = new home();
            hom.Show();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
